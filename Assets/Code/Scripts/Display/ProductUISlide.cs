using UnityEngine;
using UnityEngine.UI;

public class ProductUISlide : ProductUIBehaviour
{
    [SerializeField] private Toggle _toggle;

    public override void Setup(SO_Product product)
    {
        base.Setup(product);
    }
    public void Setup(SO_Product product, ToggleGroup group)
    {
        Setup(product);
        _toggle.group = group;
    }
}