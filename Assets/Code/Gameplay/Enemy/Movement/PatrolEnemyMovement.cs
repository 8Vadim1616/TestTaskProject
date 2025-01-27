using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Movement;
using UnityEngine;

namespace Code.Gameplay.Enemy.Movement
{
	public class PatrolEnemyMovement : MonoBehaviour, IMovable
	{
		[SerializeField] private List<Transform> _patrolPoints;
		[SerializeField] private float _speed;
		private Mover _mover;

		public float Speed => _speed;

		public Transform Transform => transform;

		private void Awake() =>
			SetMover(new PointByPointMover(this, _patrolPoints.Select(p => p.position)));

		private void Update()
		{
			if (_mover == null)
				throw new InvalidOperationException(nameof(_mover));

			_mover.Update();
		}

		private void SetMover(Mover mover)
		{
			_mover?.StopMove();

			_mover = mover;
			_mover.StartMove();
		}
	}
}