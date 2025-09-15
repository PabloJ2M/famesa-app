using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SO_ProductList))]
public class SO_ProductListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Load All Items"))
        {
            var list = target as SO_ProductList;
            list.GetAllItems();
        }
    }
}