using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "BorderlineValues")]
public class BorderlineValues : ScriptableObject
{
    public enum AttributesType{MoveSpeed, Agility, Endurance}
    [SerializeField]
    private Attribute[] attributes;
    public Attribute[] Attributes
    {
        get { return attributes; }
    }
    [Serializable]
    public class Attribute
    {
        [SerializeField]
        private Vector2 minMax;

        public Vector2 MinMax
        {
            get { return minMax; }
        }
        [SerializeField]
        private AttributesType attributeType;

        public AttributesType AttributeType 
        { 
            get { return attributeType; } 
        }

        

    }

}
