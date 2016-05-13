using System;
using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgents.Basic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Toggle))]
	public class BndToggleOnce : BaseBndComponent
	{
		private PropAgentBoolean _agent;
		private Toggle _toggle;

		[SerializeField] private string _propBool;
		[SerializeField] private bool _invert;
		[SerializeField] private Toggle.ToggleEvent _onChanged;

		protected override void InitializeAgents()
		{
			_agent = new PropAgentBoolean(SourceContext, _propBool);
		}

		protected override void InitializeComponent()
		{
			_toggle = GetComponent<Toggle>();
			_toggle.onValueChanged.AddListener(ToggleValueChanged);
		}

		private void ToggleValueChanged(bool value)
		{
			if (_invert)
			{
				value = !value;
			}
			_agent.Set(value);
			_onChanged.Invoke(value);
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _agent.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			var value = _agent.Value;
			if (_invert)
			{
				value = !value;
			}
			_toggle.isOn = value;
		}
	}
}
