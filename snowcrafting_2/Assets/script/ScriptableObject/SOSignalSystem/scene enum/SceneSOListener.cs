using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneSOListener : MonoBehaviour
{
    public SceneSOSignal signal;
    public UnityEvent<SceneEnum> signalEvent;

    private void OnEnable()
    {
        signal.RegisterListeners(this);
    }

    private void OnDisable()
    {
        signal.DeRegisterListeners(this);
    }

    public void OnSignalRaise(SceneEnum scene)
    {
        signalEvent.Invoke(scene);
    }
}
