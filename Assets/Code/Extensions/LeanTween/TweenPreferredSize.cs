using UnityEngine.UI;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(LayoutElement))]
    public class TweenPreferredSize : TweenTransform
    {
        [SerializeField] protected Axis _axis = Axis.X | Axis.Y;
        [SerializeField] protected Vector2 _override;

        protected LayoutElement _layout;

        protected override void Awake()
        {
            base.Awake();
            _layout = GetComponent<LayoutElement>();
        }
        protected virtual void Start()
        {
            _to = _override == Vector2.zero ? new(_layout.preferredWidth, _layout.preferredHeight) : _override;
            if (!_tweenCore.IsEnabled) OnUpdate(_from);
        }

        protected override void OnPerformePlay(bool value)
        {
            var from = value ? _from : _to;
            var to = value ? _to : _from;

            LTDescr tween = LeanTween.value(_self, from, to, _tweenCore.Time);
            tween.setOnUpdateVector3(OnUpdate);
            tween.setOnComplete(OnComplete);
            _tweenID = tween.id;
        }
        protected override void OnUpdate(Vector3 value)
        {
            if (_axis.HasFlag(Axis.X)) _layout.preferredWidth = value.x;
            if (_axis.HasFlag(Axis.Y)) _layout.preferredHeight = value.y;
        }
    }
}