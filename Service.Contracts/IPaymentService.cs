using PayStack.Net;
using Shared.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPaymentService
    {
        Task<TransactionInitializeResponse> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<PaymentDto> GetUserPaymentAsync(Guid paymentId);
        Task<IEnumerable<PaymentDto>> GetUserPaymentsAsync();
        Task<bool> Verify(string Reference);
    }
}
