using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.ObjectCreator;
using UnityEngine;

namespace Code.Gameplay.Enemy.Factory
{
	public class EnemyFactory : IEnemyFactory
	{
		public const string ChaseEnemyPath = "Prefab/Game/ChaseEnemy";
		public const string FireEnemyPath = "Prefab/Game/FireEnemy";
		public const string PatrolEnemyPath = "Prefab/Game/PatrolEnemy";

		private readonly IAssetProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public EnemyFactory(IAssetProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public void Create(EnemyType type)
		{
			switch (type)
			{
				case EnemyType.Chase:
					CreateChaseEnemy();
					break;
				case EnemyType.Fire:
					CreateFireEnemy();
					break;
				case EnemyType.Patrol:
					CreatePatrolEnemy();
					break;
			}
		}

		private void CreateChaseEnemy()
		{
			Vector3 position = new Vector3(-10f, 0.5f, -15f);
			GameObject prefab = _assetsProvider.LoadAsset(ChaseEnemyPath);
			_objectsCreator.Instantiate(prefab,position);
		}

		private void CreateFireEnemy()
		{
			Vector3 position = new Vector3(16f, 0.5f, 16f);
			GameObject prefab = _assetsProvider.LoadAsset(FireEnemyPath);
			_objectsCreator.Instantiate(prefab, position);

		}

		private void CreatePatrolEnemy()
		{
			Vector3 position = new Vector3(10f, 0.5f, -10f);
			GameObject prefab = _assetsProvider.LoadAsset(PatrolEnemyPath);
			_objectsCreator.Instantiate(prefab, position);
		}
	}
}