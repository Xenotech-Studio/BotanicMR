using System.Collections;
using UnityEngine;
using Versee.Scripts.PlayerControl;

[ExecuteInEditMode]
public class GM_ResetCameraPoseOnEditorOpen : MonoBehaviour
{
    public Camera CurrentMainCamera;

    public float Delay = 0.1f;

    // Start is called before the first frame update
    public void OnEnable()
    {
         // CurrentMainCamera = GetComponentInChildren<Camera>();
        
;        StartCoroutine(ResetCameraPose());
    }

    private IEnumerator ResetCameraPose()
    {
        yield return new WaitForSeconds(Delay);
        
        #if UNITY_EDITOR

        if (!UnityEditor.EditorApplication.isPlaying)
        {

            Transform XROrigin = GetComponentInChildren<VXRSimulator>(includeInactive: true).transform;

            CurrentMainCamera.transform.position = XROrigin.transform.position + new Vector3(0, 1.75f, 0);

            CurrentMainCamera.transform.rotation = Quaternion.Euler(15f, XROrigin.rotation.eulerAngles.y, 0);
            
        }

        #endif
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(GM_ResetCameraPoseOnEditorOpen))]
public class GM_ResetCameraPoseOnEditorOpenEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        GM_ResetCameraPoseOnEditorOpen myScript = (GM_ResetCameraPoseOnEditorOpen)target;

        DrawDefaultInspector();
        
        if (GUILayout.Button("Reset Camera Pose"))
        {
            myScript.OnEnable();
        }
    }
}
#endif
