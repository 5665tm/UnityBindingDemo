using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgentWrappers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Image))]
	public class BndImageFill : BaseBndComponent
	{
		private WrapperNumericAgents _agent;
		private Image _image;

		[SerializeField]
		private string _propName;

		[SerializeField]
		private float _max = 100;

		protected override void InitializeAgents()
		{
			_agent = new WrapperNumericAgents(SourceContext, _propName);
		}

		protected override void InitializeComponent()
		{
			_image = GetComponent<Image>();
		}

		protected override bool CheckForPropertiesChanged()
		{
			return _agent.RefreshProperty();
		}

		protected override void OnChangedProperties()
		{
			switch (_agent.AgentType)
			{
				case WrapperNumericAgents.NumAgentType.Float:
					_image.fillAmount = _agent.GetFloat()/_max;
					return;
				case WrapperNumericAgents.NumAgentType.Integer:
					_image.fillAmount = _agent.GetInt()/_max;
					return;
			}
		}
	}
}