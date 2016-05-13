using System;
using System.Collections.Generic;
using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgentWrappers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Text))]
	public class BndTextMulti : BaseBndText
	{
		[SerializeField]
		private List<string> _propNames;

		private List<WrapperBasicAgents> _propAgents = new List<WrapperBasicAgents>();
		private object[] _propValues;

		protected override void InitializeAgents()
		{
			foreach (var propName in _propNames)
			{
				_propAgents.Add(new WrapperBasicAgents(SourceContext, propName,
					true, true, true, true));
			}
			_propValues = new object[_propAgents.Count];
		}

		protected override bool CheckForPropertiesChanged()
		{
			bool changed = false;
			foreach (var agent in _propAgents)
			{
				if (agent.RefreshProperty())
				{
					changed = true;
				}
			}
			return changed;
		}

		protected override void OnChangedProperties()
		{
			for (int i = 0; i < _propAgents.Count; i++)
			{
				var agent = _propAgents[i];
				switch (agent.AgentType)
				{
					case WrapperBasicAgents.EAgentType.Boolean:
						_propValues[i] = agent.GetBool();
						break;
					case WrapperBasicAgents.EAgentType.Float:
						_propValues[i] = agent.GetFloat();
						break;
					case WrapperBasicAgents.EAgentType.Integer:
						_propValues[i] = agent.GetInt();
						break;
					case WrapperBasicAgents.EAgentType.String:
						_propValues[i] = agent.GetString();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			TextComponent.text = string.Format(Format, _propValues);
		}
	}
}