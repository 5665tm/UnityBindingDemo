using UnityEngine;
using UnityEngine.UI;

namespace UI.BndSystem.BindedComponents.Base
{
	public abstract class BaseBndInteractable : BaseBndComponent
	{
		[SerializeField] private bool _invert;
		[SerializeField] protected string PropName;

		private bool _prevInteractable;

		private Selectable _selectable;

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