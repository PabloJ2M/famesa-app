using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ProductCategoryAttribute))]
public class ProductCategoryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var categoryAttribute = attribute as ProductCategoryAttribute;

        string[] options = null;
        var field = typeof(ProductCategory).GetField(categoryAttribute.OptionsFieldName,
            BindingFlags.Public | BindingFlags.Static);

        if (field != null)
            options = field.GetValue(null) as string[];

        if (options == null || options.Length == 0)
        {
            EditorGUI.LabelField(position, label.text, "No options found");
            return;
        }

        if (property.propertyType == SerializedPropertyType.String)
        {
            int index = Mathf.Max(0, Array.IndexOf(options, property.stringValue));
            int newIndex = EditorGUI.Popup(position, label.text, index, options);
            property.stringValue = options[newIndex];
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use [ProductCategory] with string only");
        }
    }
}