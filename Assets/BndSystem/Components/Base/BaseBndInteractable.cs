using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Core.UI.BndSystem.Components.Base
{
	public abstract class BaseBndInteractable : BaseBndComponent
	{
		[SerializeField]
		private bool _invert;

		private bool _prevInteractable;

		private Selectable _selectable;
		[SerializeField]
		protected string PropName;

		protected override void InitializeComponent()
		{
			_selectable = GetComponent<Selectable>();
			_selectable.interactable = false;
			_prevInteractable = false;
		}

		protected void SetInteractable(bool interactable)
		{
			if (_invert)
			{
				interactable = !interactable;
			}
			if (_prevInteractable == interactable)
			{
				return;
			}
			_prevInteractable = interactable;
			_selectable.interactable = interactable;
		}
	}
}