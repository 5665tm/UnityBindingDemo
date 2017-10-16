using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(Toggle))]
	public class BndToggleOnce : BaseBndComponent
	{
		private BoolProperty _agent;
		[SerializeField] private bool _invert;
		[SerializeField] private Toggle.ToggleEvent _onChanged;

		[SerializeField] private string _propBool;
		private Toggle _toggle;

		protected override void InitializeProperties()
		{
			_agent = InitProperty<BoolProperty>(_propBool);
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
			_agent.Value = value;
			_onChanged.Invoke(value);
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