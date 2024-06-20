using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VoidSOSignal : ScriptableObject
{
    private List<VoidSOListener> listeners = new List<VoidSOListener>();

    public void Raise()
    {
        for(int i = listeners.Count-1 ; i >= 0; i--)
        {
            listeners[i].OnSignalRaise();
        }
    }

    public void RegisterListeners(VoidSOListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListeners(VoidSOListener listener)
    {
        listeners.Remove(listener);
    }
}

