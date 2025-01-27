using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States
{
	public class BootstrapState : IState
	{
		private readonly IGameStatesMachine _gameStatesMachine;

		public BootstrapState(IGameStatesMachine gameStatesMachine) => 
			_gameStatesMachine = gameStatesMachine;

		public void Enter() => 
			_gameStatesMachine.SwitchStateTo<GameLoopState>();

		public void Exit()
		{
		}
	}
}