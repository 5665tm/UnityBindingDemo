using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(Image))]
	public class BndSpriteAlpha : BaseBndComponent
	{
		private FloatProperty _agent;
		private Image _image;

		[SerializeField] private string _propName;

		protected override void InitializeProperties()
		{
			_agent = InitProperty<FloatProperty>(_propName);
		}

		protected override void InitializeComponent()
		{
			_image = GetComponent<Image>();
		}

		protected override void OnChangedProperties()
		{
			var color = _image.color;
			color.a = _agent.Value;
			_image.color = color;
		}
	}
}