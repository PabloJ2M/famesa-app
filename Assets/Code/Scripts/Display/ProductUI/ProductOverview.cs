using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class ProductOverview : SingletonBasic<ProductOverview>
{
    [SerializeField] private GameObject _overview;

    [Header("UI")]
    [SerializeField] private Image _productImage;
    [SerializeField] private TextMeshProUGUI _productName;
    [SerializeField] private TextMeshProUGUI _category;

    [Header("Viewers")]
    [SerializeField] private PdfViewer _pdfViewer;
    [SerializeField] private VideoRender _videoViewer;

    private SO_Product _current;

    protected override void Awake()
    {
        base.Awake();
        if (!Application.isEditor) CloseView();
    }

    public void CloseView() => _overview.SetActive(false);
    public void OpenView(SO_Product product)
    {
        _current = product;
        _overview.SetActive(true);

        _productImage.sprite = product.Image;
        _productName.SetText(product.Name);
        _category.SetText(product.Category);
    }

    public void OpenVideo()
    {
        _videoViewer.gameObject.SetActive(true);
        _videoViewer.Play(_current.Video);
    }
    public void OpenFichaTecnica()
    {
        _pdfViewer.gameObject.SetActive(true);
        _pdfViewer.SetPages(_current.SubCategory, _current.FichaTecnica);
    }
    public void OpenFichaSeguridad()
    {
        _pdfViewer.gameObject.SetActive(true);
        _pdfViewer.SetPages(_current.SubCategory, _current.FichaDeSeguridad);
    }
}