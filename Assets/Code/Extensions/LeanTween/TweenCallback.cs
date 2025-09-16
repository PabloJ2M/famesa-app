using System;
using UnityEngine.Events;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(TweenCore))]
    public class TweenCallback : MonoBehaviour
    {
        [Flags]
        public enum CallInteraction { Enable = 2, Disable = 4 }

        [SerializeField] private CallInteraction _startHandler;
        [SerializeField] private UnityEvent<bool> _onStartedAnimation;

        [SerializeField] private CallInteraction _completeHandler;
        [SerializeField] private UnityEvent<bool> _onCompleteAnimation;

        private TweenCore _tweenCore;

        private void Awake() => _tweenCore = GetComponent<TweenCore>();
        private void OnEnable()
        {
            _tweenCore.onPlayStatusChanged += OnStartedAnimation;
            _tweenCore.onCompleteAnimation += OnCompletedAnimation;
        }
        private void OnDisable()
        {
            _tweenCore.onPlayStatusChanged -= OnStartedAnimation;
            _tweenCore.onCompleteAnimation -= OnCompletedAnimation;
        }

        private void OnStartedAnimation(bool value)
        {
            if ((!_startHandler.HasFlag(CallInteraction.Enable) && value) ||
                (!_startHandler.HasFlag(CallInteraction.Disable) && !value)) return;

            _onStartedAnimation.Invoke(value);
        }
        private void OnCompletedAnimation()
        {
            bool value = _tweenCore.IsEnabled;

            if ((!_completeHandler.HasFlag(CallInteraction.Enable) && value) ||
                (!_completeHandler.HasFlag(CallInteraction.Disable) && !value)) return;

            _onCompleteAnimation.Invoke(_tweenCore.IsEnabled);
        }
    }
}