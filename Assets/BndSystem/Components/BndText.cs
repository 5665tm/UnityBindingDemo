using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(Text))]
	public class BndText : BaseBndText
	{
		private Property _basicAgent;

		[SerializeField] private string _propName = "";

		protected override void InitializeProperties()
		{
			_basicAgent = InitProperty<Property>(_propName);
		}

		protected override void OnChangedProperties()
		{
			TextComponent.text = string.Format(Format, _basicAgent.ToString());
		}
	}
}