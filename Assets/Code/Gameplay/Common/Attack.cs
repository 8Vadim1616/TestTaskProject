using UnityEngine;

namespace Code.Gameplay.Common
{
	public class Attack : MonoBehaviour
	{
		public float Cleavage = 5f;
		public float Damage = 10;
		public float EffectiveDistance = 0.5f;
		public bool isDestractable = false;

		private Collider[] _hits = new Collider[1];
		private int _layerMask;

		private void Awake() => 
			_layerMask = 1 << LayerMask.NameToLayer("Player");

		private void Update()
		{
			if (Hit(out Collider hit))
			{
				hit.transform.GetComponent<IHealth>()?.TakeDamage(Damage);

				if(isDestractable)
					Destroy(gameObject);
			}
		}

		private bool Hit(out Collider hit)
		{
			int hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMask);
			hit = _hits.Length > 0 ? _hits[0] : null;
			return hitAmount > 0;
		}

		private Vector3 StartPoint() =>
			new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
			transform.forward * EffectiveDistance;
	}
}