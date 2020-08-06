using System.Collections;
using UnityEngine;
using ValueAnimation.Unity;

namespace ValueAnimation.Animators {
    [AddComponentMenu("Value Animations/Value Animator")]
    public class ValueAnimator : AValueAnimator {
        [SerializeField] private AValueAnimation animationClip = default;
        [SerializeField, Range(0, 1)] private float tweenValue = default;
        private Coroutine tweenCoroutine;

        private void OnValidate() {
            UpdateTweenValue();
        }

        private void Start() {
            animationClip.TweenValue = tweenValue;
        }

        public override void FadeOut(float duration = 2f) {
            if (tweenCoroutine != null) {
                StopCoroutine(tweenCoroutine);
            }

            tweenCoroutine = StartCoroutine(FadeTowards(0f,  duration));
        }

        public override void FadeIn(float duration = 2f) {
            if (tweenCoroutine != null) {
                StopCoroutine(tweenCoroutine);
            }

            tweenCoroutine = StartCoroutine(FadeTowards(1f, duration));
        }

        private void UpdateTweenValue() {
            if (animationClip != null) {
                animationClip.TweenValue = tweenValue;
            }
        }
        
        private IEnumerator FadeTowards(float target, float duration) {
            var direction = Mathf.Sign(target - tweenValue);
            var velocity = 1f / duration;

            while (Mathf.Abs(animationClip.TweenValue - target) > 0.001f) {
                tweenValue = direction > 0
                    ? Mathf.Clamp(tweenValue + velocity * Time.deltaTime, tweenValue, target)
                    : Mathf.Clamp(tweenValue - velocity * Time.deltaTime, target, tweenValue);
                UpdateTweenValue();
                yield return null;
            }

            tweenValue = target;
            UpdateTweenValue();
        }
    }
}