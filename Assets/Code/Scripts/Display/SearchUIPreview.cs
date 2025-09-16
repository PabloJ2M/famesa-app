using UnityEngine.UI;

namespace UnityEngine.Pool
{
    [RequireComponent(typeof(ScrollRect))]
    public class SearchUIPreview : PoolBehaviour<SearchUIPreviewEntry>
    {
        [SerializeField] private SearchUI _manager;

        protected override Transform _parent => _scroll.content;
        private ScrollRect _scroll;

        public string WrittenText { get; private set; }

        protected override void Awake() { base.Awake(); _scroll = GetComponent<ScrollRect>(); }

        public void SelectName(string name) => _manager.OnSubmit(name);
        public void OnUpdateInputField(string text)
        {
            ClearActiveItems();

            WrittenText = text;
            var options = _manager.List.GetProductsName(WrittenText);

            foreach (var item in options)
                _objectPool.Get().SetProductName(item);
        }
    }
}