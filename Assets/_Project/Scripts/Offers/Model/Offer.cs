using _Project.Offers.Model;

namespace _Project.Model
{

    public class Offer
    {
       public string Title { get; private set; }
       public string Description { get; private set; }
       public Resource[] Resources { get; private set; }
       public float Price { get; }
       public float Discount { get; }
       public string SpriteId { get; private set; }

       public bool HasDiscount => Discount > 0f;
       public float FakePrice => Price * (1 + Discount);

       public Offer(OfferConfig config)
       {
           Title = config.Title;
           Description = config.Description;
           Resources = config.Resources;
           Price = config.Price;
           Discount = config.Discount;
           SpriteId = config.SpriteId;
       }
       
    }
}
