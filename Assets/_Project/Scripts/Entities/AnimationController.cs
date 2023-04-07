using UnityEngine;

namespace FireAndWater.Entities
{
	[RequireComponent(typeof(Animator))]
	public class AnimationController : MonoBehaviour
	{
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat("Speed", value);
        }
    }
}