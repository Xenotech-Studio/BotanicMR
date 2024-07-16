using Dynamite3D.RealIvy;
using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using Unity.VisualScripting;
using UnityEditor;
#endif

namespace Dynamite3D.RealIvy
{
	public class GrowableIve : MonoBehaviour
	{
		[Range(0, 1)]
		public float GrowthPercentage = 0.7f;
			
		[Header("Do-not-change Setups")]
		public float BakeDelay = 0.5f;
		public IvyCaster ivyCaster;
		public IvyPreset SelectedIvy;
		
		private void OnEnable()
		{
			if (BakeDelay > 0)
				Invoke(nameof(BakeIvy), BakeDelay);
			else
				BakeIvy();
		}
		
		private void BakeIvy()
		{
			ivyCaster.CastIvy(SelectedIvy, transform.position, transform.rotation, GrowthPercentage);
		}
	}
}
