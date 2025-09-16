using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Product List", menuName = "System/Product List", order = 0)]
public class SO_ProductList : ScriptableObject
{
    [SerializeField] private SO_Product[] _products;

    public SO_Product[] Products => _products
        .Where(x => x.Image != null)
        .Where(x => x.FichaTecnica.Length != 0)
        .ToArray();

    public SO_Product[] GetProductsByName(string name) => Products
        .Where(x => x.Name.ToLower().Contains(name.ToLower()))
        .ToArray();

    public string[] GetProductsName(string name) => Products
        .Where(x => x.Name.ToLower().Contains(name.ToLower()))
        .Select(x => x.Name)
        .ToArray();

    [ContextMenu("Get All Items")]
    public void GetAllItems() => _products = Resources.LoadAll<SO_Product>("");
}