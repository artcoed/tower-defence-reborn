using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Camera _camera;
    [SerializeField] private ProductCard _productCard;
    [SerializeField] private ProductUI _productUI;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private float _buyDistanse;

    private Preview _preview;

    private void Update()
    {
        var hasHit = Physics.Raycast(_camera.ScreenPointToRay(_playerInput.GetBuyPosition()), out var hit, _buyDistanse, _floorLayer);

        if (_playerInput.Buying() && hasHit && _productCard.CanBuy(_wallet))
        {
            if (_productUI.Showed())
                _productUI.Hide();

            _preview = _productCard.SpawnPreview();
            _preview.Show(hit.point);
        }

        if (_playerInput.Browsing() && _preview == null && hasHit)
        {
            if (hit.collider.TryGetComponent<Product>(out var product))
            {
                _productUI.Show(product);
            }
        }

        if (_preview != null && hasHit)
        {
            _preview.Move(hit.point);
        }

        if (_preview != null && _playerInput.Buying() == false)
        {
            if (hasHit && _preview.HasCrossed() == false)
            {
                var product = _productCard.BuyProduct(_wallet);
                product.Place(hit.point);
            }

            _productCard.ReturnPreview(_preview);
            _preview = null;
        }
    }
}
