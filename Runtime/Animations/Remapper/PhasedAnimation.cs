using UnityEngine;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Remapper {
    [AddComponentMenu("Value Animations/Animations/Remapper/Phased Animation")]
    public class PhasedAnimation : AValueAnimation {
        private float tweenValue = default;
        public AValueAnimation[] phases = default;


        public override float TweenValue {
            get => tweenValue;
            set  {
                tweenValue = value;
                for (var i = 0; i < phases.Length; i++) {
                    phases[i].TweenValue = Mathf.Clamp01(tweenValue * phases.Length - i);
                }
            }
        }
    }
}