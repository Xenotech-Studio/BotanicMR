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
	public class OurIvyController : MonoBehaviour
	{
		public enum State
		{
			GROWTH_NOT_STARTED,
			WAITING_FOR_DELAY,
			PAUSED,
			GROWING,
			GROWTH_FINISHED,
		}

		public event Action OnGrowthStarted;
		public event Action OnGrowthPaused;
		public event Action OnGrowthFinished;

		private float currentTimer;


		public RTIvy rtIvy;
		public IvyContainer ivyContainer;
		public IvyParameters ivyParameters;

		public RuntimeGrowthParameters growthParameters;


		private State state;

		public void Awake()
		{
			//RTBakedMeshBuilder meshBuilder = ScriptableObject.CreateInstance<RTBakedMeshBuilder>();
			
			rtIvy.AwakeInit();

			state = State.GROWTH_NOT_STARTED;

			if (growthParameters.startGrowthOnAwake)
			{
				StartGrowth();
			}
		}


		[ContextMenu("Start Growth")]
		public void StartGrowth()
		{
			//RealIvyProWindowController controller = new RealIvyProWindowController();
			ivyContainer.branches = new List<BranchContainer>();
			
			rtIvy.meshFilter = GetComponent<MeshFilter>();
			rtIvy.meshRenderer = GetComponent<MeshRenderer>();
			rtIvy.mfProcessedMesh = GetComponent<MeshFilter>();
			rtIvy.mrProcessedMesh = GetComponent<MeshRenderer>();
			rtIvy.AwakeInit();
			
			
			rtIvy.InitIvy(growthParameters,ivyContainer, ivyParameters);
			rtIvy.UpdateIvy(100);
			
			//Debug.Log(growthParameters);
			//Debug.Log(rtIvy.growthParameters);
			
			rtIvy.UpdateIvy(100f);
		}
	}
}


#if UNITY_EDITOR
[CustomEditor(typeof(OurIvyController))]
public class OurIvyControllerEditor : Editor
{

	public override void OnInspectorGUI()
	{

		DrawDefaultInspector();

		serializedObject.Update();


		OurIvyController ivyController = (OurIvyController)target;

		if (GUILayout.Button("Start Growth"))
		{
			ivyController.StartGrowth();
		}
	}
}
#endif
