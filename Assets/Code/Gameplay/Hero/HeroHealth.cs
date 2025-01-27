using System;
using Code.Gameplay.Common;
using UnityEngine;

namespace Code.Gameplay.Hero
{
	public class HeroHealth : MonoBehaviour, IHealth
	{
		public event Action HealthChanged;

		[SerializeField] private float _current;
		[SerializeField] private float _max;
		[SerializeField] private float _damageCooldown = 0.5f;

		private float _lastDamageTime;

		public float Current => _current;
		public float Max => _max;

		private void Update()
		{
			if (_lastDamageTime < _damageCooldown) 
				_lastDamageTime += Time.deltaTime;
		}

		public void TakeDamage(float damage)
		{
			if (_lastDamageTime < _damageCooldown || _current <= 0)
				return;

			_current -= damage;
			_lastDamageTime = 0f;

			HealthChanged?.Invoke();

			if (_current <= 0)
			{
				_current = 0;
				Destroy(gameObject);
			}
		}
	}
}