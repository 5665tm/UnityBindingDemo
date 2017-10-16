using UnityEngine;

namespace Architecture.Core.UI.BndSystem.Components.Base
{
	public abstract class BaseBndVisibility : BaseBndComponent
	{
		[SerializeField]
		private bool _invert;

		private bool _prevVisibility = true;
		private RectTransform _rectTransform;

		private float _xScale;
		private float _yScale;
		private float _zScale;

		private string objectName;

		[SerializeField]
		protected string PropName;

		protected override void InitializeComponent()
		{
			_rectTransform = GetComponent<RectTransform>();
			_xScale = _rectTransform.localScale.x;
			_yScale = _rectTransform.localScale.y;
			_zScale = _rectTransform.localScale.z;
			objectName = gameObject.name;
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
			gameObject.name = visibility ? objectName : objectName + " [hide]";
		}
	}
}