using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ProductUIBehaviour : MonoBehaviour
{
    [SerializeField] private Image _productImage;
    [SerializeField] private TextMeshProUGUI _productName;

    private SO_Product _reference;

    public virtual void OnPreview() => ProductOverview.Instance?.OpenView(_reference);
    public virtual void Setup(SO_Product product)
    {
        _productImage.sprite = product.Image;
        _productName.text = product.Name;
        _reference = product;
    }
}