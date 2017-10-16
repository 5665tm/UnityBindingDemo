using System;
using Architecture.Core.UI.BndSystem.Properties.Base;

namespace Architecture.Core.UI.BndSystem.Properties
{
	public class IntProperty : Property<int>, INumericProperty
	{
		public float GetFloatValue()
		{
			return Convert.ToSingle(Value);
		}

		public void SetFromFloat(float value)
		{
			Value = Convert.ToInt32(value);
		}
	}
}