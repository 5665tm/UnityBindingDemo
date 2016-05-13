using System;
using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgents.Basic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Toggle))]
	public class BndToggleGroup : BaseBndComponent
	{
		private PropAgentInteger _agent;
		private Toggle _toggle;

		[SerializeField] private string _propInt;
		[SerializeField] private int _matchValue;
		[SerializeField] private IntEvent _onEnable;

		[Serializable]
		public class IntEvent : UnityEvent<int>
		{
		}

		protected override void InitializeAgents()
		{
			_agent = new PropAgentInteger(SourceContext, _propInt);
		}

		protected override void InitializeComponent()
		{
			_toggle = GetComponent<Toggle>();
			_toggle.onValueChanged.AddListener(ToggleValueChanged);
		}

		private void ToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				_agent.Set(_matchValue);
				_onEnable.Invoke(_matchValue);
			}
			else
			{
				OnChangedProperties();
			}
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _agent.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			_toggle.isOn = _agent.Value == _matchValue;
		}
	}
}