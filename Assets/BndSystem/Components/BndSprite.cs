using Architecture.Core.UI.BndSystem.Components.Base;
using Architecture.Core.UI.BndSystem.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components
{
	[RequireComponent(typeof(Image))]
	public class BndSprite : BaseBndComponent
	{
		private SpriteProperty _agent;

		private Image _image;

		[SerializeField] private string _propName;

		protected override void InitializeProperties()
		{
			_agent = InitProperty<SpriteProperty>(_propName);
		}

		protected override void InitializeComponent()
		{
			_image = GetComponent<Image>();
		}

		protected override void OnChangedProperties()
		{
			_image.sprite = _agent.Value;
		}
	}
}