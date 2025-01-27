using Code.Gameplay.Hero.Factory;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Rotation
{
	public class RotatorToTarget : MonoBehaviour
	{
		[SerializeField] private float _rotationSpeed = 5f;
		private Transform _target;

		[Inject]
		public void Constructor(IHeroFactory heroFactory) => 
			_target = heroFactory.Hero.transform;

		private void Update()
		{
			if (_target == null)
				return;

			Vector3 direction = _target.position - transform.position;

			direction.y = 0;

			if (direction.sqrMagnitude > 0.01f)
			{
				Quaternion targetRotation = Quaternion.LookRotation(direction);

				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
			}
		}
	}
}