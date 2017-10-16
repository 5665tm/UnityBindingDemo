using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components.Base
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