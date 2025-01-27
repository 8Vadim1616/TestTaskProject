using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Movement
{
	public class PointByPointMover : Mover
	{
		private const float MinDistanceToTarget = 0.05f;

		private Queue<Vector3> _targets;
		private Vector3 _currentTarget;

		public PointByPointMover(IMovable movable, IEnumerable<Vector3> targets)
		{
			_movable = movable;
			_targets = new Queue<Vector3>(targets);
		}

		public override void StartMove() => _isMoving = true;

		public override void StopMove() => _isMoving = false;

		public override void Update()
		{
			if (_isMoving == false)
				return;

			Vector3 direction = _currentTarget - _movable.Transform.position;
			_movable.Transform.Translate(direction.normalized * _movable.Speed * Time.deltaTime);

			if (direction.magnitude < MinDistanceToTarget)
				SwitchTarget();
		}

		private void SwitchTarget()
		{
			if (_currentTarget != null)
				_targets.Enqueue(_currentTarget);

			_currentTarget = _targets.Dequeue();
		}
	}
}