using UnityEngine;

namespace Code.Gameplay.Hero.Factory
{
	public interface IHeroFactory
	{
		GameObject Hero { get; }
		void Create();
	}
}