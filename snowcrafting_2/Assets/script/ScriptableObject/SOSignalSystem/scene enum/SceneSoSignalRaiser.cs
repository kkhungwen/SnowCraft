using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSoSignalRaiser : MonoBehaviour
{
    [SerializeField] private SceneEnum scene;
    [SerializeField] private SceneSOSignal signal;
    public void RaiseSignal()
    {
        signal.Raise(scene);
    }
}
