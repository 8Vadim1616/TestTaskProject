using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
	public class AssetProvider : IAssetProvider
	{
		public GameObject LoadAsset(string path)
		{
			return Resources.Load<GameObject>(path);
		}
	}
}