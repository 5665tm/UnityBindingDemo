using Architecture.Core.UI.BndSystem.Properties;
using Context;
using UnityEngine;

namespace Demo
{
	class DemoContext : BaseContext
	{
		public FloatProperty CurrentTime = new FloatProperty();
		public FloatProperty MinTime = new FloatProperty();
		public FloatProperty MaxTime = new FloatProperty();

		private void Awake()
		{
			MinTime.Value = 0;
			MaxTime.Value = 20f;
		}

		private void Update()
		{
			CurrentTime.Value += Time.deltaTime;
		}
	}
}