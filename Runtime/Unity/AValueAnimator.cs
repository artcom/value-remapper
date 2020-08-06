using UnityEngine;
using ValueAnimation.Interfaces;

namespace ValueAnimation.Unity {
    public abstract class AValueAnimator : MonoBehaviour, IValueAnimator {
        public abstract void FadeOut(float duration = 2f);
        public abstract void FadeIn(float duration = 2f);
    }
}