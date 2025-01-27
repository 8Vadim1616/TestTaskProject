using UnityEngine;

namespace Code.Gameplay.Projectile
{
	public class DestroyAfterTime : MonoBehaviour
	{
		public float timeToDestroy = 4f;

		private void Start() => 
			Destroy(gameObject, timeToDestroy);
	}
}