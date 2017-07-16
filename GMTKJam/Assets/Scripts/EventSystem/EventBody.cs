using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBody {


}

public class MovementBody : EventBody
{
    public float speed;
}

public class AxisEB : EventBody
{
    public float value;
}

public class PointsEB : EventBody
{
    public Teams team;
    public float points;
}

public class LittleNameEB : EventBody
{
    public string name;
    public int team;
}

public class TeamFaintEB : EventBody
{
    public Teams team;
}

public class SwapEB : EventBody
{
    public Teams team;
}

public class DamageEB : EventBody
{
    public float damage;
}

public class DeathEB : EventBody
{
    public GameObject entity;
}