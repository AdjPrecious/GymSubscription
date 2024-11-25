namespace Service.Contracts
{
    public interface IServiceManager
    {
        ISubscriptionService SubscriptionService { get; }
        IAuthenticationService AuthenticationService { get; }
        IPlanService PlanService { get; }

        IAttendanceService AttendanceService { get; }

        IPaymentService PaymentService { get; }

        IEmailService EmailService { get; }

    }
}
