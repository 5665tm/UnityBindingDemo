using System;
using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgentWrappers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Slider))]
	public class BndSlider : BaseBndComponent
	{
		[SerializeField] private string _minPropName;
		[SerializeField] private string _maxPropName;
		[SerializeField] private string _valuePropName;
		[SerializeField] private bool _limitersFromProperties;
		[SerializeField] private Slider.SliderEvent _onSliderChanged;

		private WrapperNumericAgents _minAgent;
		private WrapperNumericAgents _maxAgent;
		private WrapperNumericAgents _valueAgent;

		private Slider _sliderComponent;

		protected override void InitializeAgents()
		{
			if (_limitersFromProperties)
			{
				_minAgent = new WrapperNumericAgents(SourceContext, _minPropName);
				_maxAgent = new WrapperNumericAgents(SourceContext, _maxPropName);
			}
			_valueAgent = new WrapperNumericAgents(SourceContext, _valuePropName);
		}

		protected override void InitializeComponent()
		{
			_sliderComponent = GetComponent<Slider>();
			_sliderComponent.onValueChanged.AddListener(SliderValueChanged);
		}

		protected override bool CheckForPropertiesChanged()
		{
			bool changedLimiters = false;
			if (_limitersFromProperties)
			{
				changedLimiters = _minAgent.RefreshProperty() | _maxAgent.RefreshProperty();
			}
			return changedLimiters | _valueAgent.RefreshProperty();
		}

		private void SliderValueChanged(float value)
		{
			switch (_valueAgent.AgentType)
			{
				case WrapperNumericAgents.NumAgentType.Float:
					_valueAgent.SetFloat(value);
					return;
				case WrapperNumericAgents.NumAgentType.Integer:
					_valueAgent.SetInt(Convert.ToInt32(value));
					return;
			}
			_onSliderChanged.Invoke(value);
		}

		protected override void OnChangedProperties()
		{
			if (_limitersFromProperties)
			{
				switch (_minAgent.AgentType)
				{
					case WrapperNumericAgents.NumAgentType.Float:
						_sliderComponent.minValue = _minAgent.GetFloat();
						break;
					case WrapperNumericAgents.NumAgentType.Integer:
						_sliderComponent.minValue = _minAgent.GetInt();
						break;
				}

				switch (_maxAgent.AgentType)
				{
					case WrapperNumericAgents.NumAgentType.Float:
						_sliderComponent.maxValue = _maxAgent.GetFloat();
						break;
					case WrapperNumericAgents.NumAgentType.Integer:
						_sliderComponent.maxValue = _maxAgent.GetInt();
						break;
				}
			}

			switch (_valueAgent.AgentType)
			{
				case WrapperNumericAgents.NumAgentType.Float:
					_sliderComponent.value = _valueAgent.GetFloat();
					break;
				case WrapperNumericAgents.NumAgentType.Integer:
					_sliderComponent.value = _valueAgent.GetInt();
					break;
			}
		}
	}
}