using UnityEngine.UI;
using TMPro;

namespace UnityEngine.Pool
{
    [RequireComponent(typeof(Button))]
    public class SearchUIPreviewEntry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textUI;
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();
        private void OnEnable() => _button.onClick.AddListener(OnClickHandler);
        private void OnDisable() => _button.onClick.RemoveListener(OnClickHandler);

        private void OnClickHandler() => GetComponentInParent<SearchUIPreview>().SelectName(_textUI.text);
        public void SetProductName(string value) => _textUI.SetText(value);
    }
}