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
        Task<PaymentDto> GetPaymentAsync(Guid id);
        Task<bool> Verify(string Reference);
    }
}
