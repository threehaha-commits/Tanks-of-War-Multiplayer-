using System;
using System.Reflection;
using UnityEngine;

public static class FieldAssigner
{
    public static void AssignValueToField(MonoBehaviour mono, Type assignableType, object assignableValue)
    {
        Type monoType = mono.GetType();
        FieldInfo[] fieldInfos = monoType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fieldInfos)
        {
            if (field.FieldType == assignableType)
            {
                field.SetValue(mono, assignableValue);
            }
        }
    }
}