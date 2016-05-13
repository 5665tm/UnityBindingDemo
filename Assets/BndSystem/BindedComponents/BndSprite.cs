using UI.BndSystem.BindedComponents.Base;
using UI.BndSystem.PropertyAgents.Other;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents
{
	[RequireComponent(typeof(Image))]
	public class BndSprite : BaseBndComponent
	{
		[SerializeField]
		private string _propName;

		private PropAgentSprite _agent;

		private Image _image;

		protected override void InitializeAgents()
		{
			_agent = new PropAgentSprite(SourceContext, _propName);
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
			_image.sprite = _agent.Value;
		}
	}
}