using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneSOSignal : ScriptableObject
{
    private List<SceneSOListener> listeners = new List<SceneSOListener>();

    public void Raise(SceneEnum scene)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaise(scene);
        }
    }

    public void RegisterListeners(SceneSOListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListeners(SceneSOListener listener)
    {
        listeners.Remove(listener);
    }
}
