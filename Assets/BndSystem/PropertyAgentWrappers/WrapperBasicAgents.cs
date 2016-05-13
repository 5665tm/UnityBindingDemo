using UI.BndSystem.PropertyAgents.Basic;
using UnityEngine;

namespace UI.BndSystem.PropertyAgentWrappers
{
	public class WrapperBasicAgents
	{
		private PropAgentBoolean _agentBoolean;
		private PropAgentFloat _agentFloat;
		private PropAgentInteger _agentInteger;
		private PropAgentString _agentString;

		public enum EAgentType
		{
			Boolean,
			Float,
			Integer,
			String
		}

		public EAgentType AgentType { get; private set; }

		public WrapperBasicAgents(object source, string propName,
			bool booleanAllow, bool floatAllow, bool intAllow, bool stringAllow)
		{
			AgentType = GetPropertyType(source, propName);
			switch (AgentType)
			{
				case EAgentType.Boolean:
					if (!booleanAllow)
					{
						Debug.LogError("Boolean agent not supported in current context!");
						return;
					}
					_agentBoolean = new PropAgentBoolean(source, propName);
					break;
				case EAgentType.Float:
					if (!floatAllow)
					{
						Debug.LogError("Float agent not supported in current context!");
						return;
					}
					_agentFloat = new PropAgentFloat(source, propName);
					break;
				case EAgentType.Integer:
					if (!intAllow)
					{
						Debug.LogError("Integer agent not supported in current context!");
						return;
					}
					_agentInteger = new PropAgentInteger(source, propName);
					break;
				case EAgentType.String:
					if (!stringAllow)
					{
						Debug.LogError("String agent not supported in current context!");
						return;
					}
					_agentString = new PropAgentString(source, propName);
					break;
				default:
					Debug.LogError("Agent not supported in current context!");
					break;
			}
		}

		public bool GetBool()
		{
			return _agentBoolean.Value;
		}

		public float GetFloat()
		{
			return _agentFloat.Value;
		}

		public int GetInt()
		{
			return _agentInteger.Value;
		}

		public string GetString()
		{
			return _agentString.Value;
		}

		public void SetBool(bool value)
		{
			_agentBoolean.Set(value);
		}

		public void SetFloat(float value)
		{
			_agentFloat.Set(value);
		}

		public void SetInt(int value)
		{
			_agentInteger.Set(value);
		}

		public void SetString(string value)
		{
			_agentString.Set(value);
		}

		public bool RefreshProperty()
		{
			switch (AgentType)
			{
				case EAgentType.Boolean:
					return _agentBoolean.RefreshProperty();
				case EAgentType.Float:
					return _agentFloat.RefreshProperty();
				case EAgentType.Integer:
					return _agentInteger.RefreshProperty();
				default:
					return _agentString.RefreshProperty();
			}
		}

		private static EAgentType GetPropertyType(object obj, string propName)
		{
			var type = obj.GetType().GetProperty(propName).PropertyType;
			if (type == typeof (bool))
			{
				return EAgentType.Boolean;
			}
			if (type == typeof (float))
			{
				return EAgentType.Float;
			}
			if (type == typeof (int))
			{
				return EAgentType.Integer;
			}
			if (type == typeof (string))
			{
				return EAgentType.String;
			}
			Debug.LogError("Unsupported agent type: " + type);
			return EAgentType.String;
		}
	}
}