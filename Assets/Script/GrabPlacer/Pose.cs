using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XenoSDK.BuildingBlocks.GrabPlace
{
    [System.Serializable]
    public class Pose
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
    
    // custom property drawer
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Pose))]
    public class PoseDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            var pos = new Rect(position.x, position.y, position.width, position.height);
            EditorGUI.PropertyField(pos, property.FindPropertyRelative("Position"), GUIContent.none);
            pos.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.PropertyField(pos, property.FindPropertyRelative("Rotation"), GUIContent.none);
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
        }
    }
    #endif
}