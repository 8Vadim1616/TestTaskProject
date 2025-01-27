using System;
using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Movement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemy.Movement
{
	public class ChaseEnemyMovement : MonoBehaviour, IMovable
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _chaseRadius;  
		private Mover _mover;
		private Transform _target;
		private bool _isMoving;  

		public float Speed => _speed;

		public Transform Transform => transform;

		[Inject]
		public void Constructor(IHeroFactory heroFactory) =>
			_target = heroFactory.Hero.transform;

		private void Awake() =>
			SetMover(new MoveToTargetPattern(this, _target));

		private void Update()
		{
			if (_mover == null)
				throw new InvalidOperationException(nameof(_mover));

			if(_target == null)
				return;

			float distance = Vector3.Distance(transform.position, _target.position);

			if (distance <= _chaseRadius && !_isMoving)
			{
				_isMoving = true;
				_mover.StartMove();
			}
			else if (distance > _chaseRadius && _isMoving)
			{
				_isMoving = false;
				_mover.StopMove();
			}

			if (_isMoving)
			{
				_mover.Update();
			}
		}

		private void SetMover(Mover mover)
		{
			_mover?.StopMove();

			_mover = mover;
		}
	}
}