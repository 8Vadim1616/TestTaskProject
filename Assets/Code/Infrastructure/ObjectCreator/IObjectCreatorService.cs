using UnityEngine;

namespace Code.Infrastructure.ObjectCreator
{
	public interface IObjectCreatorService
	{
		GameObject Instantiate(GameObject prefab);
		GameObject Instantiate(GameObject prefab, Vector3 position);
		GameObject Instantiate(GameObject prefab, Transform parentTransform);
	}
}