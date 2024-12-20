using _Project.Model;
using _Project.Offers.Controller;
using _Project.Offers.Factory;
using _Project.Offers.View;
using _Project.StartView.View;
using UnityEngine;

namespace _Project.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private OfferConfig[] _offerConfigs;
        [SerializeField] private OffersCollectionView _viewPrefab;
        [SerializeField] private Transform _viewParent;
        [SerializeField] private StartView.View.StartView _startView;
    
        
        private StartController _startController;
        private OfferCollectionController _offerCollectionController;
        private StartModel _startModel;
        private ISpritesLoader _spritesLoader;
        private IOfferFactory _offerFactory;

        private void Start()
        {
            _offerFactory = new OfferFactory();
            _spritesLoader = new SpritesLoader();
            InitializeStartView();
        }

        private void OnDestroy()
        {
            _startController.ShowCollectionIntent -= ShowOffersCollection;
            _startController.Dispose();
            _offerCollectionController.Dispose();
        }

        private void InitializeStartView()
        {
            _startModel = new StartModel();
            _startController = new StartController(_startModel, _startView);
            
            _startController.Initialize();

            _startController.ShowCollectionIntent += ShowOffersCollection;
        }

        private void ShowOffersCollection()
        {
            _startController.Hide();
            
            OffersCollectionView instance = Instantiate(_viewPrefab, _viewParent);
            instance.Initialize(_spritesLoader);
            
            Offer[] offers = new Offer[_startModel.OffersCount.Value];
            
            for (int i = 0; i < offers.Length; i++)
            {
                OfferConfig config = _offerConfigs[Random.Range(0, _offerConfigs.Length)];
                offers[i] = _offerFactory.CreateOffer(config);
            }

            OffersCollection offersCollection = new OffersCollection(offers);
            _offerCollectionController = new OfferCollectionController(offersCollection, instance);
            _offerCollectionController.Initialize();
        }
    }
}