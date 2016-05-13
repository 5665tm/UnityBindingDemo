using UI.BndSystem.PropertyAgents.Basic;
using UnityEngine;

namespace UI.BndSystem.PropertyAgentWrappers
{
	class WrapperNumericAgents
	{
		private PropAgentFloat _agentFloat;
		private PropAgentInteger _agentInteger;

		public enum NumAgentType
		{
			Float,
			Integer,
		}

		public NumAgentType AgentType { get; private set; }

		public WrapperNumericAgents(object source, string propName)
		{
			AgentType = GetPropertyType(source, propName);
			switch (AgentType)
			{
				case NumAgentType.Float:
					_agentFloat = new PropAgentFloat(source, propName);
					break;
				case NumAgentType.Integer:
					_agentInteger = new PropAgentInteger(source, propName);
					break;
				default:
					Debug.LogError("Agent not supported in current context!");
					break;
			}
		}

		public float GetFloat()
		{
			return _agentFloat.Value;
		}

		public int GetInt()
		{
			return _agentInteger.Value;
		}

		public void SetFloat(float value)
		{
			_agentFloat.Set(value);
		}

		public void SetInt(int value)
		{
			_agentInteger.Set(value);
		}

		public bool RefreshProperty()
		{
			switch (AgentType)
			{
				case NumAgentType.Float:
					return _agentFloat.RefreshProperty();
				default:
					return _agentInteger.RefreshProperty();
			}
		}

		private static NumAgentType GetPropertyType(object obj, string propName)
		{
			var type = obj.GetType().GetProperty(propName).PropertyType;
			if (type == typeof (float))
			{
				return NumAgentType.Float;
			}
			if (type == typeof (int))
			{
				return NumAgentType.Integer;
			}
			Debug.LogError("Unsupported agent type: " + type);
			return NumAgentType.Float;
		}
	}
}
