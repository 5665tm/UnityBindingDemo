using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties;

namespace Architecture.Core.UI.BndSystem.Components
{
	public class BndInteractableBoolean : BaseBndInteractable
	{
		private BoolProperty _agentBoolean;

		protected override void InitializeProperties()
		{
			_agentBoolean = InitProperty<BoolProperty>(PropName);
		}

		protected override void OnChangedProperties()
		{
			SetInteractable(_agentBoolean.Value);
		}
	}
}