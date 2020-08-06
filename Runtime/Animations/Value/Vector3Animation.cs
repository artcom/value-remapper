using System;
using UnityEngine;
using UnityEngine.Events;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Value {
    [AddComponentMenu("Value Animations/Animations/Value/Vector3 Animation")]
    public class Vector3Animation : AValueAnimation {
        public Vector3Event onNewVector3;
        [SerializeField] private Vector3 start = default, end = default;
        [SerializeField] private AnimationCurve curve = default;
        private Vector3 current = default;
        private float tweenValue = default;

        public override float TweenValue {
            get => tweenValue;
            set {
                current = Vector3.Lerp(start, end, curve.Evaluate(value));
                onNewVector3?.Invoke(current);
                tweenValue = value;
            }
        }
    }
    
    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> {}
    
}