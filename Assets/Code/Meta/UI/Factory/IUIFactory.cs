using UnityEngine;

namespace Code.Gameplay.Common
{
	public interface IUIFactory
	{
		GameObject UIRoot { get; }
		void CreateUIRoot();
		void CreateHud();
	}
}