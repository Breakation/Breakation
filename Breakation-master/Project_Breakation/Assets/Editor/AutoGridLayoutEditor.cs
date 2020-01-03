using UnityEditor;

[CustomEditor(typeof(AutoGridLayout),false)]
[CanEditMultipleObjects]
public class AutoGridLayoutGroupEditor : Editor
{
    //SerializedProperty m_bIsColumn;
    SerializedProperty m_Column, m_Row, m_Padding, m_Spacing, m_StartCorner, m_StartAxis, m_ChildAlignment;

    protected virtual void OnEnable()
    {
        //m_bIsColumn = serializedObject.FindProperty("m_IsColumn"); 
        m_Column = serializedObject.FindProperty("m_Column");
        //m_Row = serializedObject.FindProperty("m_Row");
        m_Padding = serializedObject.FindProperty("m_Padding");
        m_Spacing = serializedObject.FindProperty("m_Spacing");
        m_StartCorner = serializedObject.FindProperty("m_StartCorner");
        m_StartAxis = serializedObject.FindProperty("m_StartAxis");
        m_ChildAlignment = serializedObject.FindProperty("m_ChildAlignment");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(m_Column, true);
        EditorGUILayout.PropertyField(m_Padding, true);
        EditorGUILayout.PropertyField(m_Spacing, true);
        EditorGUILayout.PropertyField(m_StartCorner, true);
        EditorGUILayout.PropertyField(m_StartAxis, true);
        EditorGUILayout.PropertyField(m_ChildAlignment, true);
        serializedObject.ApplyModifiedProperties();
    }
}