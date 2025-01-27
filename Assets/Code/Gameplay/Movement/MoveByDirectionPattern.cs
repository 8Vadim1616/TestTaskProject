using UnityEngine;

namespace Code.Gameplay.Movement
{
	public class MoveByDirectionPattern : Mover
	{
		private readonly Vector3 _direction;

		public MoveByDirectionPattern(IMovable movable, Vector3 direction)
		{
			_movable = movable;
			_direction = direction.normalized;
		}

		public override void StartMove() => _isMoving = true;

		public override void StopMove() => _isMoving = false;

		public override void Update()
		{
			if (!_isMoving)
				return;

			_movable.Transform.Translate(_direction * _movable.Speed * Time.deltaTime);
		}
	}
}