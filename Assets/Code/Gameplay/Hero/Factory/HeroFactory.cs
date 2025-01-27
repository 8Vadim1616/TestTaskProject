using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.ObjectCreator;
using UnityEngine;

namespace Code.Gameplay.Hero.Factory
{
	public class HeroFactory : IHeroFactory
	{
		public const string HeroPath = "Prefab/Game/Hero";

		private readonly IAssetProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public GameObject Hero { get; private set; }

		public HeroFactory(IAssetProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public void Create()
		{
			GameObject prefab = _assetsProvider.LoadAsset(HeroPath);

			Hero = _objectsCreator.Instantiate(prefab);
		}
	}
}