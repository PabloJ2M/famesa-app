using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using TMPro;

namespace UnityEngine.Video
{
    public class VideoRender : MonoBehaviour
    {
        [SerializeField] private InputActionReference _screenTouch;
        [SerializeField] private TweenCore _actionBar;

        [Header("Elements")]
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Slider _timeline;
        [SerializeField] private TextMeshProUGUI _timer;

        private float _timeDisplay;
        private bool _isDisplayed;

        private VideoPlayer _player;
        private ScreenOrientation _default;

        private void Awake()
        {
            _default = Screen.orientation;
            _player = GetComponent<VideoPlayer>();
        }
        private void Start()
        {
            _screenTouch.action.performed += OpenActionBar;
        }
        private void OnEnable()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            _screenTouch.action.Enable();
        }
        private void OnDisable()
        {
            Screen.orientation = _default;
            _screenTouch.action.Disable();
        }

        private void Update()
        {
            _timer.SetText(string.Format("{0:00}:{1:00}", (int)_player.clockTime / 60, (int)_player.clockTime % 60));
            if (!_player.isPaused) _timeline.SetValueWithoutNotify((float)(_player.time / _player.length));
            if (_player.isPaused && _toggle.isOn) _toggle.isOn = false;

            if (!_isDisplayed) return;
            _timeDisplay -= Time.deltaTime;
            if (_timeDisplay <= 0) CloseActionBar();
        }
        private void OpenActionBar(InputAction.CallbackContext ctx)
        {
            if (!_isDisplayed) _actionBar?.Play(true);
            _isDisplayed = true;
            _timeDisplay = 3f;
        }
        private void CloseActionBar()
        {
            _isDisplayed = false;
            _actionBar?.Play(false);
        }

        public void Play(VideoClip clip)
        {
            _player.clip = clip;
            //_player.targetTexture.width = (int)clip.width;
            //_player.targetTexture.height = (int)clip.height;
            _player.Play();
        }
        public void SetTimeline(float value)
        {
            long frame = (long)(value * _player.frameCount);
            _player.frame = (int)frame;
        }
        public void CloseButton()
        {
            _player.Stop();
            gameObject.SetActive(false);
        }
        public void PauseButton(bool value)
        {
            if (value) _player.Play();
            else _player.Pause();
            _toggle.isOn = value;
        }
    }
}