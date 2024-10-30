namespace Service.Contracts
{
    public interface IServiceManager
    {
        ISubscriptionService SubscriptionService { get; }
        IAuthenticationService AuthenticationService { get; }
        IPlanService PlanService { get; }

        IPaymentService PaymentService { get; }

    }
}
