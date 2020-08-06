using UnityEngine;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Remapper {
    [AddComponentMenu("Value Animations/Animations/Remapper/Proxy Value Animation")]
    public class ProxyValueAnimation : AValueAnimation {
        [SerializeField] private AValueAnimation[] animations = default;

        public override float TweenValue {
            get {
                for (var i = 0; i < animations.Length; i++) {
                    if (animations[i] != null) {
                        return animations[i].TweenValue;
                    }
                }

                return -1;
            }

            set {
                for (var i = 0; i < animations.Length; i++) {
                    var animator = animations[i];
                    if (animator != null) {
                        animator.TweenValue = value;
                    }
                }
            }
        }
    }
}