using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties;
using UnityEngine;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(RectTransform))]
	public class BndVisibilityBoolean : BaseBndVisibility
	{
		private BoolProperty _agentBoolean;

		protected override void InitializeProperties()
		{
			_agentBoolean = InitProperty<BoolProperty>(PropName);
		}

		protected override void OnChangedProperties()
		{
			SetVisible(_agentBoolean.Value);
		}
	}
}