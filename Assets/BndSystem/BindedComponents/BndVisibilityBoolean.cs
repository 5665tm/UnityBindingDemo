using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgents.Basic;
using UnityEngine;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof (RectTransform))]
	public class BndVisibilityBoolean : BaseBndVisibility
	{
		private PropAgentBoolean _agentBoolean;

		protected override void InitializeAgents()
		{
			_agentBoolean = new PropAgentBoolean(SourceContext, PropName);
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _agentBoolean.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			SetVisible(_agentBoolean.Value);
		}
	}
}