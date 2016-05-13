using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UI.BndSystem.PropertyAgents
{
	public abstract class BasePropAgent
	{
		private static readonly Dictionary<Type, Dictionary<string, MethodInfo>> _cachedGetMethods
			= new Dictionary<Type, Dictionary<string, MethodInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, MethodInfo>> _cachedSetMethods
			= new Dictionary<Type, Dictionary<string, MethodInfo>>();

		protected readonly MethodInfo GetMethod;
		protected readonly MethodInfo SetMethod;
		private bool _valueIsSet;

		protected BasePropAgent(object source, string propName)
		{
			GetMethod = GetGetPropertyMethod(source, propName);
			SetMethod = GetSetPropertyMethod(source, propName);
		}

		public bool RefreshProperty()
		{
			if (!_valueIsSet)
			{
				OnRefreshProperty();
				_valueIsSet = true;
				return true;
			}

			return OnRefreshProperty();
		}

		protected abstract bool OnRefreshProperty();

		protected static MethodInfo GetGetPropertyMethod(object source, string propertyName)
		{
			Type type = source.GetType();
			Dictionary<string, MethodInfo> dic;
			if (!_cachedGetMethods.TryGetValue(type, out dic))
			{
				dic = new Dictionary<string, MethodInfo>();
				_cachedGetMethods[type] = dic;
			}

			MethodInfo mInfo;
			if (!dic.TryGetValue(propertyName, out mInfo))
			{
				mInfo = type.GetProperty(propertyName).GetGetMethod();
				dic[propertyName] = mInfo;

				return mInfo;
			}
			return mInfo;
		}

		protected static MethodInfo GetSetPropertyMethod(object source, string propertyName)
		{
			Type type = source.GetType();
			Dictionary<string, MethodInfo> dic;
			if (!_cachedSetMethods.TryGetValue(type, out dic))
			{
				dic = new Dictionary<string, MethodInfo>();
				_cachedSetMethods[type] = dic;
			}

			MethodInfo mInfo;
			if (!dic.TryGetValue(propertyName, out mInfo))
			{
				mInfo = type.GetProperty(propertyName).GetSetMethod();
				dic[propertyName] = mInfo;

				return mInfo;
			}
			return mInfo;
		}
	}
}