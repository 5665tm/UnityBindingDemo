using System;

namespace UI.BndSystem.PropertyAgents.Basic
{
	public class PropAgentBoolean : BasePropAgent
	{
		private bool _prevValue;
		public bool Value { get; private set; }
		private readonly Func<bool> _getDelegate;
		private readonly Action<bool> _setDelegate;

		public PropAgentBoolean(object source, string propName) : base(source, propName)
		{
			Type getDelegateType = typeof (Func<bool>);
			_getDelegate = (Func<bool>) Delegate.CreateDelegate(getDelegateType,
				source, GetMethod);

			Type setDelegateType = typeof (Action<bool>);
			if (SetMethod != null)
			{
				_setDelegate = (Action<bool>) Delegate.CreateDelegate(setDelegateType,
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

		public void Set(bool value)
		{
			_setDelegate(value);
		}
	}
}