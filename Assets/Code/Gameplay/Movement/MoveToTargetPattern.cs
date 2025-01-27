using UnityEngine;

namespace Code.Gameplay.Movement
{
	public class MoveToTargetPattern : Mover
	{
		private readonly Transform _target;

		public MoveToTargetPattern(IMovable movable, Transform target)
		{
			_movable = movable;
			_target = target;
		}

		public override void StartMove() => _isMoving = true;

		public override void StopMove() => _isMoving = false;

		public override void Update()
		{
			if (_isMoving == false)
				return;

			Vector3 direction = _target.position - _movable.Transform.position;
			_movable.Transform.Translate(direction.normalized * _movable.Speed * Time.deltaTime);
		}
	}
}