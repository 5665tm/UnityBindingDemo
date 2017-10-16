using System;
using System.Collections.Generic;
using System.Reflection;
using Architecture.Core.UI.BndSystem.Properties.Base;
using UnityEngine;

namespace Architecture.Core.UI.BndSystem.Components.Base
{
	public abstract class BaseBndComponent : MonoBehaviour
	{
		private IBndTarget _sourceContext;

		private readonly List<Property> _allProperties = new List<Property>();

		protected IBndTarget SourceContext
		{
			get
			{
				return _sourceContext ?? (_sourceContext = FindInParents<IBndTarget>(gameObject));
			}
		}

		public static T FindInParents<T>(GameObject go)
		{
			if (go == null)
			{
				return default(T);
			}

			var comp = go.GetComponent<T>();

			if (comp == null)
			{
				var t = go.transform.parent;

				while (t != null && comp == null)
				{
					comp = t.gameObject.GetComponent<T>();
					t = t.parent;
				}
			}

			return comp;
		}

		protected void Start()
		{
				InitializeComponent();
				InitializeProperties();
				OnChangedProperties();
		}

		protected void OnDestroy()
		{
			foreach (Property prop in _allProperties)
			{
				prop.UnSubscribe(OnChangedProperties);
			}
			_allProperties.Clear();
		}

		protected T InitProperty<T>(string propertyName) where T : Property, new()
		{
			try
			{
				var type = SourceContext.GetType();
				FieldInfo f = type.GetField(propertyName);
				if (f == null)
				{
					return new T();
				}
				object m = f.GetValue(SourceContext);
				T property = (T) m;

				_allProperties.Add(property);
				property.Subscribe(OnChangedProperties);
				return property;
			}
			catch (Exception e)
			{
				ErrorLog(propertyName, e.StackTrace);
				return new T();
			}
		}

		private void ErrorLog(string propertyName, string add)
		{
			Debug.LogError("Error property: " + propertyName + " in " + SourceContext.GetName() + "\n" + add);
		}

		protected abstract void InitializeComponent();
		protected abstract void InitializeProperties();
		protected abstract void OnChangedProperties();
	}
}