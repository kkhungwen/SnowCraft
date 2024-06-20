using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidSOListener : MonoBehaviour
{
    public VoidSOSignal signal;
    public UnityEvent signalEvent;

    private void OnEnable()
    {
        signal.RegisterListeners(this);
    }

    private void OnDisable()
    {
        signal.DeRegisterListeners(this);
    }

    public void OnSignalRaise()
    {
        signalEvent.Invoke();
    }
}
