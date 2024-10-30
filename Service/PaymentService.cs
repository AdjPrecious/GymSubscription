using AutoMapper;
using Contract;
using Entity.EnumData;
using Entity.Exceptions;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using Service.Contracts;
using Shared.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PaymentService : IPaymentService
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly string token;


        private  PayStackApi PayStack {  get; set; }


        public PaymentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IConfiguration config)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _config = config;
            token = _config["Paystack:SecretKey"];
            PayStack = new PayStackApi(token);
        }

        public async Task<TransactionInitializeResponse> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var plan = await _repository.Plan.GetPlanAsync(createPaymentDto.PlanId);
            if (plan == null)
                throw new PlanNotFoundException(createPaymentDto.PlanId);

            var  useremail = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (useremail == null)
                throw new UserNotLoginException();
            var user = await _userManager.FindByEmailAsync(useremail);

            TransactionInitializeRequest request = new TransactionInitializeRequest()
            {
                AmountInKobo = (int)(plan.Price * 100),
                Email = user.Email,
                Plan = plan.PlanName,
                
                Reference = Generate().ToString(),
                Currency = "NGN",  
                CallbackUrl = "https://localhost:7034/swagger/payment/verify"

            };
            TransactionInitializeResponse response = PayStack.Transactions.Initialize(request);
            if (!response.Status)
                throw new InvalidOperationException(response.Message);
            var payment = new Payment
            {
                CreatedAt = DateTime.Now,
                AmountPaid = plan.Price,
                PaymentMethod = createPaymentDto.PaymentMethod,
                PlanID = plan.PlanID,
                Plan =  plan ,
                UserId = user.Id,
                User = user,
                TransactionReference = request.Reference,
            };
           await _repository.Payment.CreatePaymentAsync(payment);
            await _repository.SavechagesAsync();
             return response;    
                
        }

        public async Task<bool> Verify(string Reference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(Reference);
            if(response.Data.Status == "success")
            {
                var payment = await _repository.Payment.GetPaymentByReference(Reference);
                if(payment != null)
                {
                    payment.isSuccessfull = true;
                    payment.PaymentDate = DateTime.Now;
       
                    _repository.Payment.UpdatePayment(payment);
                    await _repository.SavechagesAsync();
                 
                    return true;
                }
            }
            return false;      
        }

        public static int Generate()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            return rnd.Next(100000000, 999999999);
        }

        public async Task<PaymentDto> GetPaymentAsync(Guid id)
        {
            var payment = await  _repository.Payment.GetPaymentAsync(id);
            if(payment == null)
                throw new PaymentNotFoundException(id);

            var paymentDto =_mapper.Map<PaymentDto>(payment);
            return paymentDto;
        }
    }
}
