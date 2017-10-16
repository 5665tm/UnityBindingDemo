using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties.Base;
using UnityEngine;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(RectTransform))]
	public class BndVisibilityNumeric : BaseBndVisibility
	{
		public enum TypeBinding
		{
			LessOrEqual = 0,
			Equal = 1,
			GreaterOrEqual = 2
		}

		[SerializeField] private float _point;
		[SerializeField] private TypeBinding _typeBinding = TypeBinding.Equal;

		private INumericProperty _agentNumeric;

		protected override void InitializeProperties()
		{
			_agentNumeric = InitProperty<Property>(PropName) as INumericProperty;
		}

		protected override void OnChangedProperties()
		{
			var visibility = false;

			switch (_typeBinding)
			{
				case TypeBinding.LessOrEqual:
					visibility = _agentNumeric.GetFloatValue() <= _point;
					break;
				case TypeBinding.Equal:
					visibility = Mathf.Abs(_agentNumeric.GetFloatValue() - _point) > 0.0001f;
					break;
				case TypeBinding.GreaterOrEqual:
					visibility = _agentNumeric.GetFloatValue() >= _point;
					break;
			}
			SetVisible(visibility);
		}
	}
}