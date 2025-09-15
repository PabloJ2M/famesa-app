using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Product", menuName = "System/Product", order = 1)]
public class SO_Product : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;

    [SerializeField, ProductCategory("Category")] private string _category;
    [SerializeField, ProductCategory("SubCategory")] private string _subCategory;

    [SerializeField] private Sprite[] _fichaTecnica;
    [SerializeField] private Sprite[] _fichaSeguridad;
    [SerializeField] private VideoClip _video;

    public Sprite Image => _sprite;
    public string Name => _name;

    public string Category => _category;
    public string SubCategory => _subCategory;

    public Sprite[] FichaTecnica => _fichaTecnica;
    public Sprite[] FichaDeSeguridad => _fichaSeguridad;
    public VideoClip Video => _video;
}