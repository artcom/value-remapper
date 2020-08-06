using UnityEngine;
using ValueAnimation.Interfaces;

namespace ValueAnimation.Unity {
    public abstract class AValueAnimation : MonoBehaviour, IValueAnimation {
        public abstract float TweenValue { get; set;  }
    }
}