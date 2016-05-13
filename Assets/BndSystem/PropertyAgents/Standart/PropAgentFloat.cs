using System;
using UnityEngine;

namespace UI.BndSystem.PropertyAgents.Basic
{
	public class PropAgentFloat : BasePropAgent
	{
		private float _prevValue;
		public float Value { get; private set; }
		private readonly Func<float> _getDelegate;
		private readonly Action<float> _setDelegate;
		private const float _TOLERANCE = 0.001f;

		public PropAgentFloat(object source, string propName) : base(source, propName)
		{
			Type getDelegateType = typeof (Func<float>);
			_getDelegate = (Func<float>) Delegate.CreateDelegate(getDelegateType,
				source, GetMethod);

			Type setDelegateType = typeof (Action<float>);
			if (SetMethod != null)
			{
				_setDelegate = (Action<float>) Delegate.CreateDelegate(setDelegateType,
					source, SetMethod);
			}
		}

		protected override bool OnRefreshProperty()
		{
			Value = _getDelegate();
			if (Mathf.Abs(Value - _prevValue) > _TOLERANCE)
			{
				_prevValue = Value;
				return true;
			}
			return false;
		}

		public void Set(float value)
		{
			_setDelegate(value);
		}
	}
}