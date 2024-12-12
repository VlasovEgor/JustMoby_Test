using _Project.Model;

namespace _Project.Offers.Factory
{
    public interface IOfferFactory
    {
        Offer CreateOffer(OfferConfig config);
    }
}