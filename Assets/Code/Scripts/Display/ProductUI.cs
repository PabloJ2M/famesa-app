using UnityEngine;

public class ProductUI : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ProductUIBehaviour _prefab;

    public SO_Product[] Products { private get; set; }

    private void Start()
    {
        foreach (var product in Products)
            Instantiate(_prefab, _container).Setup(product);

        if (_prefab.gameObject.activeInHierarchy)
            _prefab.gameObject.SetActive(false);
    }
}