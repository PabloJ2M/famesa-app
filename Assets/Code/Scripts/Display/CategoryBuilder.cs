using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryBuilder : MonoBehaviour
{
    [SerializeField] private SO_ProductList _list;
    [SerializeField] private ToggleGroup _group;
    [SerializeField] private CategoryElement _prefab;

    [Header("Constructor")]
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField, ProductCategory("Category")] private string _category;

    private void Awake()
    {
        _header.SetText(_category);

        var products = _list.Products.GetProductsByCategory(_category);
        var subCategories = products.GetSubCategories();

        foreach (var subCategory in subCategories)
            Instantiate(_prefab, transform).SetupElements(products, subCategory, _group);
    }
}