using UnityEngine;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Value {
    [AddComponentMenu("Value Animations/Animations/Value/Position Offset Animation")]
    public class PositionOffsetAnimation : AValueAnimation {
        private float tweenValue = default;
        [SerializeField] private AnimationCurve curve = default;

        public override float TweenValue {
            get => tweenValue;
            set {
                rectTransform.anchoredPosition = Vector2.Lerp(start, end, curve.Evaluate(value));
                tweenValue = value;
            }
        }

        [SerializeField] private RectTransform rectTransform = default;
        [SerializeField] private Vector2 origin = default;
        [SerializeField] private Vector2 offset = default;
        [SerializeField] private Vector2 start = default;
        private Vector2 end => origin;

        private void OnValidate() {
            if (rectTransform != null) {
                origin = rectTransform.anchoredPosition;
                start = origin + offset;
            }
        }
    }
}