﻿namespace Entity.Model
{
    public class Plan
    {
        public Guid PlanID { get; set; }
        public string? PlanName { get; set; }
        public float Price { get; set; }
        public int DurationInDays {  get; set; }
        public string? Description {  get; set; }

        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}
