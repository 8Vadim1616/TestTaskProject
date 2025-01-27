using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Projectile.Factory;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootting
{
	public class Shooter : MonoBehaviour
	{
		[SerializeField] private float _shootingRange = 10f;
		[SerializeField] private float _shootingInterval = 1f;
		
		private float _lastShotTime;
		
		private IProjectileFactory _projectileFactory;
		private Transform _target;

		[Inject]
		public void Constructor(IProjectileFactory projectileFactory, IHeroFactory heroFactory)
		{
			_projectileFactory = projectileFactory;
			_target = heroFactory.Hero.transform;
		}

		private void Update()
		{
			if (_target == null)
				return;

			float distanceToTarget = Vector3.Distance(transform.position, _target.position);
			if (distanceToTarget <= _shootingRange)
			{
				if (Time.time - _lastShotTime >= _shootingInterval)
				{
					Shoot();
					_lastShotTime = Time.time;
				}
			}
		}

		private void Shoot() => 
			_projectileFactory.Create(transform.position);
	}
}