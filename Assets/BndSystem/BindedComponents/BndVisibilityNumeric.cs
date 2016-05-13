using System;
using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgentWrappers;
using UnityEngine;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof (RectTransform))]
	public class BndVisibilityNumeric : BaseBndVisibility
	{
		public enum TypeBinding
		{
			LessOrEqual = 0,
			Equal = 1,
			GreaterOrEqual = 2
		}

		[SerializeField]
		private float _point;

		private int _pointInt;

		[SerializeField]
		private TypeBinding _typeBinding = TypeBinding.Equal;

		private float _TOLERANCE = 0.001f;

		private WrapperNumericAgents _agentNumeric;

		protected override void InitializeAgents()
		{
			_agentNumeric = new WrapperNumericAgents(SourceContext, PropName);
			if (_agentNumeric.AgentType == WrapperNumericAgents.NumAgentType.Integer)
			{
				_pointInt = Convert.ToInt32(_point);
			}
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _agentNumeric.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			bool visibility = false;

			switch (_agentNumeric.AgentType)
			{
				case WrapperNumericAgents.NumAgentType.Float:
					switch (_typeBinding)
					{
						case TypeBinding.LessOrEqual:
							visibility = _agentNumeric.GetFloat() <= _point;
							break;
						case TypeBinding.Equal:
							visibility = Mathf.Abs(_agentNumeric.GetFloat() - _point) < _TOLERANCE;
							break;
						case TypeBinding.GreaterOrEqual:
							visibility = _agentNumeric.GetFloat() >= _point;
							break;
					}
					break;
				case WrapperNumericAgents.NumAgentType.Integer:
					switch (_typeBinding)
					{
						case TypeBinding.LessOrEqual:
							visibility = _agentNumeric.GetInt() <= _pointInt;
							break;
						case TypeBinding.Equal:
							visibility = _agentNumeric.GetInt() == _pointInt;
							break;
						case TypeBinding.GreaterOrEqual:
							visibility = _agentNumeric.GetInt() >= _pointInt;
							break;
					}
					break;
			}
			SetVisible(visibility);
		}
	}
}