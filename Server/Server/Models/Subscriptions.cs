namespace Server.Models
{
    public class Subscriptions
    {
        public int SubscriptionsId { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public Subscriptions(int subscriptionsId, int firstUserId, int secondUserId)
        {
            SubscriptionsId = subscriptionsId;
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }
    }
}
