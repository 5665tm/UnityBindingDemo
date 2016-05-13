using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UI.Context;
using UnityEngine;

namespace Assets.Context
{
	class DemoContext : BaseContext
	{
		public float CurrentTime { get; set; }
		public float MinTime { get; private set; }
		public float MaxTime { get; private set; }

		private void Awake()
		{
			MinTime = 0;
			MaxTime = 20f;
		}

		private void Update()
		{
			CurrentTime += Time.deltaTime;
		}
	}
}