using Architecture.Core.UI.BndSystem.Components.Base;
using UnityEngine;

namespace Context
{
	public abstract class BaseContext : MonoBehaviour, IBndTarget
	{
		public string GetName()
		{
			return gameObject.name;
		}
	}
}