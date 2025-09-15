using TMPro;

namespace UnityEngine.UI
{
    public class ToggleString : ToggleBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textUI;
        [SerializeField] private int _stringIndex;
        [SerializeField] private string _textOn, _textOff;

        private string _defaultText;

        protected override void Awake() { base.Awake(); _defaultText = _textUI?.text; }
        protected override void Start() { base.Start(); UpdateText(isOn); }
        protected override void OnUpdateValue(bool value) { if (Application.isPlaying) UpdateText(value); }

        protected void UpdateText(bool value) => _textUI?.SetText(string.Format(_defaultText, value ? _textOn : _textOff));
        public void SetText(string value)
        {
            _defaultText = value.Insert(Mathf.Clamp(_stringIndex, 0, value.Length), " {0} ");
            UpdateText(isOn);
        }
    }
}