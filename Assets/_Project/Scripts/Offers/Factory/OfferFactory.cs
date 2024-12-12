using _Project.Model;

namespace _Project.Offers.Factory
{
    public class OfferFactory: IOfferFactory
    {
        public Offer CreateOffer(OfferConfig config)
        {
            return new Offer(config);
        }
    }
}