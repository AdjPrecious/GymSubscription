using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ISubscriptionRepository> _subscriptionRepository;
        private readonly Lazy<IPlanRespository> _planRespository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IAttendanceRepository> _attendanceRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _subscriptionRepository = new Lazy<ISubscriptionRepository>(() => new SubscriptionRepository(repositoryContext));
            _planRespository = new Lazy<IPlanRespository>(() => new PlanRepository(repositoryContext));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(repositoryContext));
            _attendanceRepository = new Lazy<IAttendanceRepository>(() => new AttendanceRepository(repositoryContext));
        }
        public ISubscriptionRepository Subscription => _subscriptionRepository.Value;

        public IPlanRespository Plan => _planRespository.Value ;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public IAttendanceRepository Attendance => _attendanceRepository.Value;

        public async Task SavechagesAsync() => await _repositoryContext.SaveChangesAsync();
        
    }
}
