using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace _Stone.Tools
{
    [CreateAssetMenu(fileName ="CustonInspector",menuName ="CustonIspector")]
    public class CustonInspectorMaster : ScriptableObject
    {

    }

}

namespace _Stone.Tools
{
    [CustomEditor(typeof(CustonInspectorMaster))]
    public class InspectorControl : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();



        }
    }
    [CustomEditor(typeof(spell))]
    public class SpellEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }


        private void BasicSelectedInfoEdit(string PropertyName)
        {
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty SpellLIstFild = so.FindProperty(PropertyName);
            EditorGUILayout.PropertyField(SpellLIstFild, true); // True means show children
            so.ApplyModifiedProperties();
        }
    }
}

