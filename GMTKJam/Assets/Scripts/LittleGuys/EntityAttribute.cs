using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityAttribute {
    public string name;
    public AttributeTypes type;
    public float maxValue;
    public float initialValue;
    public float currentValue;

    public string Name {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }

    }

    public AttributeTypes Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }

    }

    public float MaxValue
    {
        get
        {
            return maxValue;
        }
        set
        {
            maxValue = value;
        }

    }

    public float InitialValue
    {
        get
        {
            return initialValue;
        }
        set
        {
            initialValue = value;
        }

    }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
        }

    }
}
