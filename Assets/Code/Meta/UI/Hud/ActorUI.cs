using Code.Gameplay.Hero.Factory;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Common
{
	public class ActorUI : MonoBehaviour
	{
		public HpBar HpBar;

		private IHealth _health;

		[Inject]
		public void Constructor(IHeroFactory heroFactory) =>
			_health = heroFactory.Hero.GetComponent<IHealth>();

		private void OnEnable() => 
			_health.HealthChanged += UpdateHpBar;

		private void OnDestroy() => 
			_health.HealthChanged -= UpdateHpBar;

		private void UpdateHpBar() => 
			HpBar.SetValue(_health.Current, _health.Max);
	}
}