#if TMPro
using TMPro;
#endif
using UnityEngine;
using UnityEngine.UI;
using ValueAnimation.Unity;

namespace ValueAnimation.Animations.Value {
    [AddComponentMenu("Value Animations/Animations/Value/Opacity Animation")]
    public class OpacityAnimation : AValueAnimation {
        [SerializeField] private Graphic[] graphics = default;
        [SerializeField] private AnimationCurve alphaValue = default;
        private float tweenValue = default;

        public override float TweenValue {
            get => tweenValue;
            set {
                value = alphaValue.Evaluate(value);
                for (var i = 0; i < graphics.Length; i++) {
                    var element = graphics[i];
#if TextMeshPro
                    if (element is TextMeshProUGUI tmp) {
                        var color = tmp.color;
                        color.a = value;
                        tmp.color = color;
                        continue;
                    }
#endif
                    element.canvasRenderer.SetAlpha(value);
                }
                tweenValue = value;
            }
        }
    }
}