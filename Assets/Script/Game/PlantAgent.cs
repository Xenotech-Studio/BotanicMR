using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class PlantAgent : MonoBehaviour
{
    public string PlantId;
    public UnityEvent<float> OnProgressChange;
    [Range(0, 1)] public float _progress;

    public string PlantUID;
    
    public bool RecordWhenGrowIsCalled = false;
    
    public float Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            OnProgressChange.Invoke(_progress);
        }
    }
    
    public void GrowToProgress(float progress)
    {
        Progress = progress;
        if (RecordWhenGrowIsCalled)
        {
            RecordToGameProgressData();
        }
    }

    public void RecordToGameProgressData()
    {
        MainController.RecordPlant(this);
    }
    
    public void RemovePlant()
    {
        MainController.RemovePlant(this);
        Destroy(gameObject);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlantAgent))]
public class PlantAgentEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        PlantAgent plantAgent = (PlantAgent) target;
        
        if (GUILayout.Button("Grow to 70%"))
        {
            plantAgent.GrowToProgress(0.7f);
        }
        
        if (GUILayout.Button("RecordToGameProgressData"))
        {
            plantAgent.RecordToGameProgressData();
        }
        
        if (GUILayout.Button("RemovePlant"))
        {
            plantAgent.RemovePlant();
        } 
    }
}
#endif