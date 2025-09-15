using UnityEngine.Animations;

namespace UnityEngine.UI
{
    public class ToggleSwipe : ToggleBehaviour
    {
        private TweenSwipe _animation;

        protected override void Awake()
        {
            base.Awake();
            _animation = GetComponentInChildren<TweenSwipe>();
        }
        protected override void OnUpdateValue(bool value)
        {
            if (!Application.isPlaying) return;
            _animation.SetStatus(!value);
        }
    }
}