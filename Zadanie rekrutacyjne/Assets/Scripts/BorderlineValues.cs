using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "BorderlineValues")]
public class BorderlineValues : ScriptableObject
{
    public enum AttributesType{MoveSpeed, Agility, Endurance, JumpHeight}
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
        [SerializeField]
        private AttributesType attributeType;

        public Attribute(Vector2 minMax, AttributesType attributeType)
        {
            this.minMax = minMax;
            this.attributeType = attributeType;
        }

    }

}
