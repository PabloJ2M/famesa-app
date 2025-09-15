using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Product List", menuName = "System/Product List", order = 0)]
public class SO_ProductList : ScriptableObject
{
    [SerializeField] private SO_Product[] _products;

    public SO_Product[] Products => _products;

    public SO_Product[] GetProductsByCategory(string category, string subCategory) => _products
        .Where(x => category == x.Category)
        .Where(x => subCategory == x.SubCategory)
        .ToArray();

    [ContextMenu("Get All Items")]
    public void GetAllItems() => _products = Resources.LoadAll<SO_Product>("");
}