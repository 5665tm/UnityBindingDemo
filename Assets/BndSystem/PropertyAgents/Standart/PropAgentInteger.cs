using System;

namespace UI.BndSystem.PropertyAgents.Basic
{
	public class PropAgentInteger : BasePropAgent
	{
		private int _prevValue;
		public int Value { get; private set; }
		private readonly Func<int> _getDelegate;
		private readonly Action<int> _setDelegate;

		public PropAgentInteger(object source, string propName) : base(source, propName)
		{
			Type getDelegateType = typeof (Func<int>);
			_getDelegate = (Func<int>) Delegate.CreateDelegate(getDelegateType,
				source, GetMethod);

			Type setDelegateType = typeof (Action<int>);
			if (SetMethod != null)
			{
				_setDelegate = (Action<int>) Delegate.CreateDelegate(setDelegateType,
					source, SetMethod);
			}
		}

		protected override bool OnRefreshProperty()
		{
			Value = _getDelegate();
			if (Value != _prevValue)
			{
				_prevValue = Value;
				return true;
			}
			return false;
		}

		public void Set(int value)
		{
			_setDelegate(value);
		}
	}
}