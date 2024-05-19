namespace StripePaymentTestApi.utils
{
    public sealed class StripePaymentSingleInstance
    {
        private static readonly Object s_lock = new object();
        private static StripePaymentSingleInstance instance = null;

        public static StripePaymentSingleInstance StripePaymentInstance
        {
            get
            {
                if(instance != null) return instance;
                Monitor.Enter(s_lock);
                StripePaymentSingleInstance temp = new StripePaymentSingleInstance();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(s_lock);
                return instance;
            
            }
        }

        public StripeCardManager stripeCardManager;
        private StripePaymentSingleInstance()
        {
            stripeCardManager = new StripeCardManager();
        }
    }
}
