using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductUpgrade : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _lockUpgradeText;

    public void Show(Product product)
    {
        _image.sprite = product.Sprite;
        _priceText.text = product.GetPrice().ToString();
    }

    public void Lock(Sprite sprite)
    {
        _image.sprite = sprite;
        _priceText.gameObject.SetActive(false);
        _lockUpgradeText.gameObject.SetActive(true);
    }
}
