using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class GameEvent: UnityEvent<EventBody>
{

}

public class EventManager : MonoBehaviour
{
    private Dictionary<string, GameEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, GameEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction<EventBody> listener)
    {
        GameEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new GameEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<EventBody> listener)
    {
        if (eventManager == null) return;
        GameEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, EventBody eventData)
    {
        GameEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventData);
        }
    }
}