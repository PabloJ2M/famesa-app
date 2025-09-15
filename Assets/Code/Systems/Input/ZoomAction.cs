using System;
using Unity.Mathematics;

namespace UnityEngine.InputSystem
{
    using EnhancedTouch;
    using Touch = EnhancedTouch.Touch;

    public class ZoomAction : MonoBehaviour
    {
        [SerializeField] private InputActionReference _zoomOverrideAction;

        /// <summary>interaction point, zoom in & out</summary>
        public static event Action<float2, float> performed;
        public static event Action cancel;

        private const float _minDistance = 0.001f;
        private bool _enabled = false;

        private void Start() => _zoomOverrideAction.action.performed += DefaultAction;
        private void OnEnable()
        {
            _zoomOverrideAction.action.Enable();
            EnhancedTouchSupport.Enable();
        }
        private void OnDisable()
        {
            _zoomOverrideAction.action.Disable();
            EnhancedTouchSupport.Disable();
        }

        private void DefaultAction(InputAction.CallbackContext ctx)
        {
            float2 scroll = ctx.ReadValue<Vector2>();
            float zoom = scroll.y * 0.1f;

            if (math.abs(zoom) <= _minDistance) return;

            performed?.Invoke(Mouse.current.position.value, zoom);
            cancel?.Invoke();
        }
        private void CancelAction()
        {
            if (!_enabled) return;
            _enabled = false;
            cancel?.Invoke();
        }

        private void Update()
        {
            if (Touch.activeTouches.Count < 2) { CancelAction(); return; }
            var t0 = Touch.activeTouches[0];
            var t1 = Touch.activeTouches[1];
            _enabled = true;

            float currentDistance = math.distance(t0.screenPosition, t1.screenPosition);
            float previousDistance = math.distance(t0.screenPosition - t0.delta, t1.screenPosition - t1.delta);

            float pinchZoomValue = (currentDistance - previousDistance) * 0.01f;
            if (Mathf.Abs(pinchZoomValue) < _minDistance) return;

            float2 midPoint = (t0.screenPosition + t1.screenPosition) * 0.5f;
            performed?.Invoke(midPoint, pinchZoomValue);
        }
    }
}