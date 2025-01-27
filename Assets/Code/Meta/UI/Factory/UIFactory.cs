using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.ObjectCreator;
using UnityEngine;

namespace Code.Gameplay.Common
{
	public class UIFactory : IUIFactory
	{
		public const string UIRootPath = "Prefab/Game/UIRoot";
		public const string HudPath = "Prefab/Game/Hud";

		private readonly IAssetProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public GameObject UIRoot { get; private set; }

		public UIFactory(IAssetProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public void CreateUIRoot()
		{
			GameObject prefab = _assetsProvider.LoadAsset(UIRootPath);

			UIRoot = _objectsCreator.Instantiate(prefab);
		}

		public void CreateHud()
		{
			GameObject prefab = _assetsProvider.LoadAsset(HudPath);

			Debug.Log(UIRoot);

			_objectsCreator.Instantiate(prefab, UIRoot.transform);
		}
	}
}