using Code.Gameplay.Movement;
using UnityEngine;

namespace Code.Gameplay.Projectile
{
	public class ProjectileMover : MonoBehaviour, IMovable
	{
		[SerializeField] private float _speed;
		private Mover _mover;

		public float Speed => _speed;

		public Transform Transform => transform;

		private void Awake()
		{
			SetMover(new MoveByDirectionPattern(this, transform.forward));
			_mover.StartMove();
		}

		private void Update()
		{
			_mover?.Update();
		}

		private void SetMover(Mover mover)
		{
			_mover?.StopMove();

			_mover = mover;
		}
	}
}