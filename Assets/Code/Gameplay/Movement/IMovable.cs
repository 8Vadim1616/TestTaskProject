using UnityEngine;

namespace Code.Gameplay.Movement
{
	public interface IMovable
	{
		Transform Transform { get; }
		float Speed { get; }
	}
}