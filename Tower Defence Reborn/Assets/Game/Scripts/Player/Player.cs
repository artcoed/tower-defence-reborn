using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Camera _camera;
    [SerializeField] private ProductUI _productUI;
    [SerializeField] private List<ProductCard> _productCards;
    [SerializeField] private List<BoostCard> _boostCards;
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private float _distance;

    private Preview _preview;
    private ProductCard _interactProductCard;
    private Product _interactProduct;

    private void Update()
    {
        Debug.Log(_productUI.Selling());

        if (_playerInput.Pressing() && _productUI.Showed() && _productUI.Clicking() == false)
        {
            _productUI.Hide();
            _interactProduct = null;
        }

        var hasFloorHit = Physics.Raycast(_camera.ScreenPointToRay(_playerInput.GetPosition()), out var floorHit, _distance, _floorMask);

        if (_playerInput.Pressing() && _preview == null)
        {
            foreach (var productCard in _productCards)
            {
                if (productCard.Clicking())
                {
                    if (productCard.CanBuy(_wallet))
                    {
                        _preview = productCard.SpawnPreview();
                        _preview.Show(floorHit.point);
                        _interactProductCard = productCard;
                    }

                    break;
                }
            }

            foreach (var boostCard in _boostCards)
            {
                if (boostCard.Clicking() && boostCard.CanBuy(_wallet))
                    boostCard.Buy(_wallet);
            }
        }

        var hasProductHit = Physics.Raycast(_camera.ScreenPointToRay(_playerInput.GetPosition()), out var productHit, _distance);

        if (_playerInput.Pressing() && _preview == null && _productUI.Clicking() == false && hasProductHit)
        {
            if (productHit.collider.TryGetComponent<Product>(out var product))
            {
                _productUI.Show(product);
                _interactProduct = product;
            }
        }

        if (_preview != null && hasFloorHit)
            _preview.Move(floorHit.point);

        if (_preview != null && _playerInput.Pressing() == false)
        {
            if (hasFloorHit && _preview.HasCrossed() == false)
            {
                var product = _interactProductCard.BuyProduct(_wallet);
                product.Place(floorHit.point);
            }

            _interactProductCard.ReturnPreview(_preview);
            _preview = null;
        }

        if (_interactProduct != null && _productUI.Selling())
        {
            _wallet.Earn(_interactProduct.GetSellPrice());
            Destroy(_interactProduct.gameObject);
            _productUI.Hide();
            _interactProduct = null;
        }
    }
}
