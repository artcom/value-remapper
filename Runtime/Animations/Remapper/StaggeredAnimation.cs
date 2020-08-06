using UnityEngine;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Remapper {
    [AddComponentMenu("Value Animations/Animations/Remapper/Staggered Animation")]
    public class StaggeredAnimation : AValueAnimation {
        private float tweenValue = default;

        [SerializeField, Range(0, 1)] private float overlapping = default;
        [SerializeField] private AValueAnimation[] phases = default;

        public override float TweenValue {
            get => tweenValue;
            set {
                tweenValue = value;
                var blockWaitSize = 1f / (phases.Length + 1) * overlapping;
                var blockSize = Mathf.Lerp(1 - blockWaitSize, blockWaitSize, overlapping);
                //var blockSize = Mathf.Lerp(1, 1f / (enablingPhases.Length + 1), staggering);
                // var blockWaitSize = blockSize * staggering;
                for (var i = 0; i < phases.Length; i++) {
                    var lowerEdge = blockWaitSize * i;
                    var upperEdge = lowerEdge + blockSize;
                    phases[i].TweenValue = Remap(tweenValue, lowerEdge, upperEdge, 0, 1);
                }   
            }
        }
        
        private static float Remap(float value, float start1, float stop1, float start2, float stop2) {
            return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
        }
    }
}