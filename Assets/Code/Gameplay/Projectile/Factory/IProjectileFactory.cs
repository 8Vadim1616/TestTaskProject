using UnityEngine;

namespace Code.Gameplay.Projectile.Factory
{
	public interface IProjectileFactory
	{
		void Create(Vector3 position);
	}
}