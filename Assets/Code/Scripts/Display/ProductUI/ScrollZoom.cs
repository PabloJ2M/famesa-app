using Unity.Mathematics;
using UnityEngine.InputSystem;

namespace UnityEngine.UI
{
    public class ScrollZoom : MonoBehaviour
    {
        [SerializeField] private float2 _zoomClamp = new(1f, 3f);
    
        private ScrollRect _scrollRect;
        private float _scale = 1f;

        private void Awake() => _scrollRect = GetComponent<ScrollRect>();
        private void OnEnable()
        {
            ZoomAction.performed += OnPerformeAction;
            ZoomAction.cancel += OnCancelAction;
        }
        private void OnDisable()
        {
            ZoomAction.performed -= OnPerformeAction;
            ZoomAction.cancel -= OnCancelAction;
        }

        private void OnPerformeAction(float2 pointer, float delta)
        {
            _scrollRect.enabled = false;

            float newScale = _scale + delta;
            if (newScale < _zoomClamp.x || newScale > _zoomClamp.y) return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.content, pointer, null, out Vector2 localPoint);

            _scale = math.clamp(newScale, _zoomClamp.x, _zoomClamp.y);

            _scrollRect.content.localScale = new float3(_scale, _scale, 1f);
            _scrollRect.content.anchoredPosition -= delta * localPoint;
        }
        private void OnCancelAction()
        {
            _scrollRect.enabled = true;
        }
    }
}