using Code.Gameplay.Common;
using Code.Gameplay.Enemy.Factory;
using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Input;
using Code.Gameplay.Projectile.Factory;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.ObjectCreator;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
			BindStates();
			BindInfrastructureServices();
			BindCommonServices();
			BindGameplayServices();
			BindStateMachines();
			BindFactories();
		}

		private void BindStateMachines() => 
			Container.BindInterfacesAndSelfTo<GameStatesMachine>().AsSingle();

		private void BindStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
		}

		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
		}

		private void BindCommonServices()
		{
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
		}

		private void BindGameplayServices()
		{
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IInputService>().To<InputService>().AsSingle();
		}


		private void BindFactories()
		{
			Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
			Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
			Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
			Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
			Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
		}


		public void Initialize() => 
			Container.Resolve<IGameStatesMachine>().SwitchStateTo<BootstrapState>();
	}
}
