using System.Linq;
using UnityEngine;

public class ProductCategoryAttribute : PropertyAttribute
{
    public string OptionsFieldName { get; private set; }

    public ProductCategoryAttribute(string optionsFieldName)
    {
        OptionsFieldName = optionsFieldName;
    }
}
public static class ProductCategory
{
    public static string[] Category =
    {
        "Altos Explosivos",
        "Sistemas de iniciaci�n",
        "Agentes de voladura"
    };
    public static string[] SubCategory =
    {
        "Cebos o iniciadores",
        "Tradicionales | Convencionales",
        "Encartuchados",
        "Voladura de contorno",
        "Emulsi�n sensibilizada",
        "El�ctricos",
        "El�ctricos | Electr�nicos",
        "No el�ctricos",
        "Emulsi�n gasificable",
        "Anfo"
    };

    public static SO_Product[] GetProductsByCategory(this SO_Product[] products, string category) => products
        .Where(x => category == x.Category)
        .Where(x => x.Image != null)
        .Where(x => x.FichaTecnica.Length != 0)
        .ToArray();
    
    public static SO_Product[] GetProductBySubCategory(this SO_Product[] products, string category) => products
        .Where(x => category == x.SubCategory)
        .ToArray();

    public static string[] GetSubCategories(this SO_Product[] products) => products
        .Select(x => x.SubCategory)
        .Distinct()
        .ToArray();
}