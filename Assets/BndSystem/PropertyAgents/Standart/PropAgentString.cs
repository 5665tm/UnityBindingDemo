using System;

namespace UI.BndSystem.PropertyAgents.Basic
{
	public class PropAgentString : BasePropAgent
	{
		private string _prevValue;
		public string Value { get; private set; }
		private readonly Func<string> _getDelegate;
		private readonly Action<string> _setDelegate;

		public PropAgentString(object source, string propName) : base(source, propName)
		{
			Type getDelegateType = typeof (Func<string>);
			_getDelegate = (Func<string>) Delegate.CreateDelegate(getDelegateType,
				source, GetMethod);

			Type setDelegateType = typeof (Action<string>);
			if (SetMethod != null)
			{
				_setDelegate = (Action<string>) Delegate.CreateDelegate(setDelegateType,
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

		public void Set(string value)
		{
			_setDelegate(value);
		}
	}
}