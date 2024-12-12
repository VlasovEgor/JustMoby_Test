using _Project.Offers.Model;
using UnityEngine;

namespace _Project.Model
{
    [CreateAssetMenu(menuName = "Create OfferContainer", fileName = "OfferContainer", order = 0)]
    public class OfferConfig : ScriptableObject
    {   
        public string Title => _title;
        public string Description => _description;
        public Resource[] Resources => _resources;
        public float Price => _price;
        public float Discount => _discount;
        public string SpriteId => _spriteId;
        
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Resource[] _resources;
        [SerializeField] private float _price;
        [SerializeField, Range(0f,1f)] private float _discount;
        [SerializeField] private string _spriteId;
    }
}