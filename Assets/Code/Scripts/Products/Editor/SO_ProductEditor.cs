using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomEditor(typeof(SO_Product))]
public class SO_ProductEditor : Editor
{
    private SO_Product item => target as SO_Product;
    private readonly GUILayoutOption[] _options = { GUILayout.Width(100), GUILayout.Height(100) };

    public override void OnInspectorGUI()
    {
        SO_Product product = target as SO_Product;
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_name"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_category"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_subCategory"));

        SerializedProperty sprite = serializedObject.FindProperty("_sprite");
        sprite.objectReferenceValue = EditorGUILayout.ObjectField(sprite.objectReferenceValue, typeof(Sprite), false, _options);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_fichaTecnica"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_fichaSeguridad"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_video"));

        serializedObject.ApplyModifiedProperties();
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        if (item.Image == null) return Default();

        Type type = GetType("UnityEditor.SpriteUtility");
        if (type == null) return Default();

        MethodInfo method = type.GetMethod("RenderStaticPreview", new[] { typeof(Sprite), typeof(Color), typeof(int), typeof(int) });
        if (method == null) return Default();

        object ret = method.Invoke("RenderStaticPreview", new object[] { item.Image, Color.white, width, height });
        if (ret is Texture2D) return ret as Texture2D;
        return Default();

        Texture2D Default() => base.RenderStaticPreview(assetPath, subAssets, width, height);
    }
    private static Type GetType(string typeName)
    {
        var type = Type.GetType(typeName);
        if (type != null) return type;

        var currentAssembly = Assembly.GetExecutingAssembly();
        var referencedAssemblies = currentAssembly.GetReferencedAssemblies();

        foreach (var assemblyName in referencedAssemblies)
        {
            var assembly = Assembly.Load(assemblyName);
            if (assembly == null) continue;

            type = assembly.GetType(typeName);
            if (type != null) return type;
        }

        return null;
    }
}