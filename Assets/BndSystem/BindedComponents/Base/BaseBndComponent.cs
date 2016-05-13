using System;
using UI.Context;
using UnityEngine;

namespace UI.BndSystem.BindedComponents.Base
{
	public abstract class BaseBndComponent : MonoBehaviour
	{
		[SerializeField]
		private TrackType _trackType = TrackType.EveryFrame;

		private int _frameCounter;

		private bool _componentItsOk;

		public enum TrackType
		{
			NonTracked = 0,
			One5Frame = 1,
			EveryFrame = 2
		}

		private BaseContext _sourceContext;
		protected BaseContext SourceContext
		{
			get { return _sourceContext ?? (_sourceContext = FindInParents<BaseContext>(gameObject)); }
		}

		protected void Start()
		{
			try
			{
				InitializeAgents();
				InitializeComponent();
				DoWork();
				_componentItsOk = true;
			}
			catch (Exception ex)
			{
				Debug.LogError("Error in Binding Component" +
					"\nContext: " + SourceContext.name + "    Game object: " + name
					+ "\n" + ex.Message + ex.StackTrace);
				_componentItsOk = false;
			}
		}

		private void Update()
		{
			if (!_componentItsOk)
			{
				return;
			}

			switch (_trackType)
			{
				case TrackType.NonTracked:
					return;
				case TrackType.One5Frame:
					if (++_frameCounter == 5)
					{
						_frameCounter = 0;
						DoWork();
					}
					break;
				case TrackType.EveryFrame:
					DoWork();
					break;
			}
		}

		private void DoWork()
		{
			if (CheckForPropertiesChanged())
			{
				OnChangedProperties();
			}
		}

		protected abstract void InitializeAgents();
		protected abstract void InitializeComponent();
		protected abstract bool CheckForPropertiesChanged();
		protected abstract void OnChangedProperties();

		public static T FindInParents<T>(GameObject go) where T : Component
		{
			if (go == null)
			{
				return null;
			}

			T comp = go.GetComponent<T>();

			if (comp == null)
			{
				Transform t = go.transform.parent;

				while (t != null && comp == null)
				{
					comp = t.gameObject.GetComponent<T>();
					t = t.parent;
				}
			}

			return comp;
		}
	}
}