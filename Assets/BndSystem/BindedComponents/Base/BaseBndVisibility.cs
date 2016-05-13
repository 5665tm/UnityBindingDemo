using UnityEngine;

namespace UI.BndSystem.BindedComponents.Base
{
	public abstract class BaseBndVisibility : BaseBndComponent
	{
		[SerializeField]
		private bool _invert;

		[SerializeField]
		protected string PropName;

		private bool _prevVisibility = true;

		private string gameName;

		private float _xScale;
		private float _yScale;
		private float _zScale;
		private RectTransform _rectTransform;

		protected override void InitializeComponent()
		{
			_rectTransform = GetComponent<RectTransform>();
			_xScale = _rectTransform.localScale.x;
			_yScale = _rectTransform.localScale.y;
			_zScale = _rectTransform.localScale.z;
			gameName = gameObject.name;
		}

		protected void SetVisible(bool visibility)
		{
			if (_invert)
			{
				visibility = !visibility;
			}
			if (_prevVisibility == visibility)
			{
				return;
			}
			_prevVisibility = visibility;
			_rectTransform.localScale = new Vector3(
				visibility ? _xScale : 0,
				_yScale,
				_zScale
				);
			gameObject.name = visibility ? gameName : gameName + " [hide]";
		}
	}
}