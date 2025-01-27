using Code.Gameplay.Hero.Factory;
using UnityEngine;
using Zenject;

namespace Code.Common.Camera
{
	public class CameraFollowing : MonoBehaviour
	{
		private Vector3 offset = new(0, 5, -10);
		private Transform _target;

		[Range(0, 1)]
		public float smoothSpeed = 0.125f;

		[Inject]
		public void Constructor(IHeroFactory heroFactory) => 
			_target = heroFactory.Hero.transform;

		private void LateUpdate()
		{
			if (_target == null)
				return;

			Vector3 desiredPosition = _target.position + offset;

			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

			transform.position = smoothedPosition;

			transform.LookAt(_target);
		}
	}
}