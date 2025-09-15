using UnityEditor;
using UnityEditor.UI;

namespace UnityEngine.UI
{
    [CustomEditor(typeof(ToggleString))]
    public class ToggleStringEditor : ToggleEditor
    {
        private SerializedProperty _textUI;
        private SerializedProperty _stringIndex;
        private SerializedProperty _stringOn;
        private SerializedProperty _stringOff;

        protected override void OnEnable()
        {
            base.OnEnable();
            _textUI = serializedObject.FindProperty("_textUI");
            _stringIndex = serializedObject.FindProperty("_stringIndex");
            _stringOn = serializedObject.FindProperty("_textOn");
            _stringOff = serializedObject.FindProperty("_textOff");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Text Toggle", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_textUI);
            EditorGUILayout.PropertyField(_stringIndex);
            EditorGUILayout.PropertyField(_stringOn);
            EditorGUILayout.PropertyField(_stringOff);

            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            base.OnInspectorGUI();
        }
    }
}