using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Common
{
	public class HpBar : MonoBehaviour
	{
		public RectTransform Bar;
		public void SetValue(float current, float max)
		{
			float normalizedValue = Mathf.Clamp01(current / max);
			Bar.localScale = new Vector3(normalizedValue, 1f, 1f);
		}
	}
}