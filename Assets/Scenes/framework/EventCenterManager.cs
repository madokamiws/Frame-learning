using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenterManager : SingletonPatternBase<EventCenterManager>
{
    Dictionary<string, UnityAction> eventsDictionary = new Dictionary<string, UnityAction>();

    /// <summary>
    /// º‡Ã˝√¸¡Ó
    /// </summary>
    /// <param name="key"></param>
    /// <param name="call"></param>
    public void AddListener(object command, UnityAction call)
    {
        string key = command.GetType().Name+"_"+command.ToString();
        if (eventsDictionary.ContainsKey(key))
        {
            eventsDictionary[key] += call;
        }
        else
            eventsDictionary.Add(key, call);

    }
    /// <summary>
    /// ∑¢ÀÕ√¸¡Ó
    /// </summary>
    /// <param name="key"></param>
    public void Dispatch(object command)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if (eventsDictionary.ContainsKey(key))
        {
            eventsDictionary[key]?.Invoke();
        }
    }

    public void RemoveListener(object command, UnityAction call)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if (eventsDictionary.ContainsKey(key))
        {
            eventsDictionary[key] -= call;
        }
    }

}
