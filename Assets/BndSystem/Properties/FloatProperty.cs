using Architecture.Core.UI.BndSystem.Properties.Base;

namespace Architecture.Core.UI.BndSystem.Properties
{
	public class FloatProperty : Property<float>, INumericProperty
	{
		public float GetFloatValue()
		{
			return Value;
		}

		public void SetFromFloat(float value)
		{
			Value = value;
		}
	}
}
