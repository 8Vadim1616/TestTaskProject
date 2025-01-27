using Code.Gameplay.Common;
using Code.Gameplay.Enemy;
using Code.Gameplay.Enemy.Factory;
using Code.Gameplay.Hero.Factory;
using Code.Infrastructure.Loading;

namespace Code.Infrastructure.States
{
	public class GameLoopState : IState
	{
		private readonly ISceneLoader _sceneLoader;
		private readonly IHeroFactory _heroFactory;
		private readonly IEnemyFactory _enemyFactory;

		public void Enter()
		{
			_sceneLoader.LoadScene(Scenes.Gameplay);

			_uiFactory.CreateUIRoot();
			CreateHero();
			_uiFactory.CreateHud();
			CreateEnemies();
		}

		private readonly IUIFactory _uiFactory;

		public GameLoopState(
			ISceneLoader sceneLoader, 
			IHeroFactory heroFactory,
			IEnemyFactory enemyFactory,
			IUIFactory uiFactory)
		{
			_sceneLoader = sceneLoader;
			_heroFactory = heroFactory;
			_enemyFactory = enemyFactory;
			_uiFactory = uiFactory;
		}

		public void Exit()
		{
		}

		private void CreateHero()
		{
			_heroFactory.Create();
		}

		private void CreateEnemies()
		{
			_enemyFactory.Create(EnemyType.Chase);
			_enemyFactory.Create(EnemyType.Fire);
			_enemyFactory.Create(EnemyType.Patrol);
		}
	}
}