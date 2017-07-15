using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour {

    public int PointsPerCycle;
    public float PointCycleDuration;
    private bool startCapturing;
    private float capturedDuration;

    private List<Teams> teamsCapturing;

    public void Awake()
    {
        teamsCapturing = new List<Teams>();
        capturedDuration = 0.0f;
        startCapturing = false;
    }

    public void Update(){
        if(teamsCapturing.Count == 1)
        {
            if (startCapturing)
            {
                capturedDuration += Time.deltaTime;
                if(capturedDuration > PointCycleDuration)
                {
                    EventManager.TriggerEvent("IncrementPoints", new PointsEB { team = teamsCapturing[0], points = PointsPerCycle });
                    startCapturing = false;
                    capturedDuration = 0.0f;
                }
            }
            else
            {
                startCapturing = true;
            }
        }
        else
        {
            startCapturing = false;
            capturedDuration = 0.0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        LittleGuy collidedEntity = null;
        if(collidedEntity = collision.gameObject.GetComponent<LittleGuy>())
        {
            teamsCapturing.Add(collidedEntity.CurrentTeam);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        LittleGuy collidedEntity = null;
        if (collidedEntity = collision.gameObject.GetComponent<LittleGuy>())
        {
            teamsCapturing.Remove(collidedEntity.CurrentTeam);
        }
    }
}
