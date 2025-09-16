using UnityEngine.UI;
using TMPro;

namespace UnityEngine.Pool
{
    [RequireComponent(typeof(ScrollRect))]
    public class SearchUI : PoolBehaviour<ProductUISlide>
    {
        [Header("UI Controller")]
        [SerializeField] private TMP_InputField _field;
        [SerializeField] private SearchUIPreview _searchList;

        [Header("Product List")]
        [SerializeField] private ToggleGroup _group;
        [SerializeField] private SO_ProductList _list;

        protected override Transform _parent => _scroll.content;
        public SO_ProductList List => _list;

        private ScrollRect _scroll;

        protected override void Awake() { base.Awake(); _scroll = GetComponent<ScrollRect>(); }
        private void Start() => DisplayResults(_list.Products);

        private void OnEnable()
        {
            _field.onSubmit.AddListener(OnSubmit);
            _field.onSelect.AddListener(OnSelectInput);
            _field.onValueChanged.AddListener(OnValueChange);
        }
        private void OnDisable()
        {
            _field.onSubmit.RemoveListener(OnSubmit);
            _field.onSelect.RemoveListener(OnSelectInput);
            _field.onValueChanged.RemoveListener(OnValueChange);
        }

        private void OnSelectInput(string text) => _searchList.gameObject.SetActive(true);
        private void OnValueChange(string text)
        {
            OnSelectInput(text);
            _searchList?.OnUpdateInputField(text);
        }

        public void CloseInput() => _searchList.gameObject.SetActive(false);

        public void OnSubmit(string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            DisplayResults(_list.GetProductsByName(name));
            _field.SetTextWithoutNotify(name);
        }
        private void DisplayResults(SO_Product[] list)
        {
            _group.SetAllTogglesOff(true);
            ClearActiveItems();
            CloseInput();

            foreach (var item in list)
                _objectPool.Get().Setup(item, _group);
        }
    }
}