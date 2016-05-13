using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgentWrappers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Text))]
	public class BndText : BaseBndText
	{
		[SerializeField]
		private string _propName = "";

		private WrapperBasicAgents _basicAgent;

		protected override void InitializeAgents()
		{
			_basicAgent = new WrapperBasicAgents(SourceContext, _propName,
				true, true, true, true);
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _basicAgent.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			switch (_basicAgent.AgentType)
			{
				case WrapperBasicAgents.EAgentType.Boolean:
					TextComponent.text = string.Format(Format, _basicAgent.GetBool());
					return;
				case WrapperBasicAgents.EAgentType.Float:
					TextComponent.text = string.Format(Format, _basicAgent.GetFloat());
					return;
				case WrapperBasicAgents.EAgentType.Integer:
					TextComponent.text = string.Format(Format, _basicAgent.GetInt());
					return;
				default:
					TextComponent.text = string.Format(Format, _basicAgent.GetString());
					return;
			}
		}
	}
}