namespace Code.Gameplay.Movement
{
	public abstract class Mover
	{
			protected IMovable _movable;

			protected bool _isMoving;

			public abstract void StartMove();

			public abstract void StopMove();

			public abstract void Update();
	}
}