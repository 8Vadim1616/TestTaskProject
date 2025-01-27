namespace Code.Infrastructure.States.StateMachine
{
	public interface IGameStatesMachine
	{
		void SwitchStateTo<TState>() where TState : class, IState;
	}
}