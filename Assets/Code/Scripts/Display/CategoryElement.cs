using UnityEngine;
using UnityEngine.UI;

public class CategoryElement : MonoBehaviour
{
    [SerializeField] private ToggleString _toggle;
    [SerializeField] private ProductUI _products;

    public void SetupElements(SO_Product[] products, string subCategory, ToggleGroup group = null)
    {
        _products.Products = products.GetProductBySubCategory(subCategory);

        if (!_toggle) return;
        _toggle.SetText(subCategory);
        _toggle.group = group;
    }
}