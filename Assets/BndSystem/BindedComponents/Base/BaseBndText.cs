using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents.Base
{
	public abstract class BaseBndText : BaseBndComponent
	{
		[SerializeField]
		protected string Format = "{0}";

		protected Text TextComponent;

		protected override void InitializeComponent()
		{
			TextComponent = GetComponent<Text>();
		}
	}
}