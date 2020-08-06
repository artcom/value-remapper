using System;
using UnityEngine;
using UnityEngine.Events;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Value {
    [AddComponentMenu("Value Animations/Animations/Value/Float Animation")]
    public class FloatAnimation : AValueAnimation{
        public FloatEvent onNewFloat;

        [SerializeField] private float start = default, end = default;
        [SerializeField] private AnimationCurve curve = default;
        private float current = default;
        private float tweenValue = default;

        public override float TweenValue {
            get => tweenValue;
            set {
                current = Mathf.Lerp(start, end, curve.Evaluate(value));
                onNewFloat?.Invoke(current);
                tweenValue = value;
            }
        }
    }
    
    [Serializable]
    public class FloatEvent : UnityEvent<float> {}
}