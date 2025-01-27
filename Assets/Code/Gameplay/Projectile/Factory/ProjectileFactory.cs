using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.ObjectCreator;
using UnityEngine;

namespace Code.Gameplay.Projectile.Factory
{
	public class ProjectileFactory : IProjectileFactory
	{
		public const string ProjectilePath = "Prefab/Game/Projectile";

		private readonly IAssetProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public ProjectileFactory(IAssetProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public void Create(Vector3 position)
		{
			GameObject prefab = _assetsProvider.LoadAsset(ProjectilePath);
			_objectsCreator.Instantiate(prefab, position);
		}
	}
}