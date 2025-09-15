using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

public class PdfViewer : PoolBehaviour<Image>
{
    [SerializeField] private ButtonString _backButton;
    private ScrollRect _rect;

    protected override Transform _parent => _rect.content;
    protected override void Awake() { base.Awake(); _rect = GetComponent<ScrollRect>(); }

    public void SetPages(string subCategory, Sprite[] pages)
    {
        _backButton.SetText(subCategory);
        ClearActiveItems();

        for (int i = 0; i < pages.Length; i++)
        {
            var item = _objectPool.Get();
            item.sprite = pages[i];
            item.transform.SetSiblingIndex(i);
        }
    }
}