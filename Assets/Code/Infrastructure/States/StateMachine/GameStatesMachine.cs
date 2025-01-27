using Code.Infrastructure.States.Factory;

namespace Code.Infrastructure.States.StateMachine
{
	public class GameStatesMachine : IGameStatesMachine
	{
		private IExitableState _activeState;

		private readonly IStateFactory _stateFactory;

		public GameStatesMachine(IStateFactory stateFactory) => 
			_stateFactory = stateFactory;

		public void SwitchStateTo<TState>() where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_activeState?.Exit();

			TState state = _stateFactory.GetState<TState>();
			_activeState = state;

			return state;
		}
	}
}