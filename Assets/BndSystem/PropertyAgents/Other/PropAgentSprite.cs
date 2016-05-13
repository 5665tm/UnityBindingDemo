using System;
using UnityEngine;

namespace UI.BndSystem.PropertyAgents.Other
{
	public class PropAgentSprite : BasePropAgent
	{
		private Sprite _prevValue;
		public Sprite Value { get; private set; }
		private readonly Func<Sprite> _getDelegate;
		private readonly Action<Sprite> _setDelegate;

		public PropAgentSprite(object source, string propName) : base(source, propName)
		{
			Type getDelegateType = typeof (Func<Sprite>);
			_getDelegate = (Func<Sprite>) Delegate.CreateDelegate(getDelegateType,
				source, GetMethod);

			Type setDelegateType = typeof (Action<Sprite>);
			if (SetMethod != null)
			{
				_setDelegate = (Action<Sprite>) Delegate.CreateDelegate(setDelegateType,
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

		public void Set(Sprite value)
		{
			_setDelegate(value);
		}
	}
}