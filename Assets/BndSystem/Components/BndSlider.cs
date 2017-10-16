using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(Slider))]
	public class BndSlider : BaseBndComponent
	{
		[SerializeField]
		private string _valuePropName;
		private INumericProperty _valueAgent;

		[Space(20), SerializeField]
		private Slider.SliderEvent _onSliderChanged;

		private Slider _sliderComponent;

		protected override void InitializeProperties()
		{
			_valueAgent = InitProperty<Property>(_valuePropName) as INumericProperty;
		}

		protected override void InitializeComponent()
		{
			_sliderComponent = GetComponent<Slider>();
			_sliderComponent.onValueChanged.AddListener(SliderValueChanged);
		}

		private void SliderValueChanged(float value)
		{
			_valueAgent.SetFromFloat(value);
			_onSliderChanged.Invoke(value);
		}

		protected override void OnChangedProperties()
		{
			_sliderComponent.value = _valueAgent.GetFloatValue();
		}
	}
}