using System;

namespace Architecture.Core.UI.BndSystem.Properties.Base
{
	public class Property
	{
		public Property()
		{
		}

		protected Action OnChanged;

		public void Subscribe(Action onChanged)
		{
			OnChanged += onChanged;
		}

		public void UnSubscribe(Action onChanged)
		{
			OnChanged -= onChanged;
		}
	}

	public abstract class Property<T> : Property
	{
		public T Value
		{
			get
			{
				return Get();
			}
			set
			{
				Set(value);
			}
		}

		private T _value;

		public Property()
		{
			_value = default(T);
		}

		public Property(T value)
		{
			_value = value;
		}

		private T Get()
		{
			return _value;
		}

		private void Set(T value)
		{
			if (IsChanged(value))
			{
				_value = value;
				if (OnChanged != null)
				{
					OnChanged();
				}
			}
		}

		protected virtual bool IsChanged(T newValue)
		{
			var changed = (newValue == null && _value != null)
						|| (newValue != null && _value == null)
						|| ((newValue != null) && !newValue.Equals(_value));
			return changed;
		}

		public override string ToString()
		{
			if (_value == null)
			{
				return "";
			}
			return Value.ToString();
		}
	}

	public interface INumericProperty
	{
		float GetFloatValue();
		void SetFromFloat(float value);
	}
}