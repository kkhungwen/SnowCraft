using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private bool change = false;
    [SerializeField] private bool talk = false;
    [SerializeField] SpeechBubble speechBubble;
    private void OnEnable()
    {
        InputManager.Instance.OnTest_started += DebugInput;
        InputManager.Instance.OnTest_performed += DebugInput;
        InputManager.Instance.OnTest_canceled += DebugInput;
    }
    private void OnDisable()
    {
        InputManager.Instance.OnTest_started -= DebugInput;
        InputManager.Instance.OnTest_performed -= DebugInput;
        InputManager.Instance.OnTest_canceled -= DebugInput;
    }

    private void Update()
    {
        if (change)
        {
            change = false;
            ChangePosition();
        }
        if (talk)
        {
            talk = false;
            speechBubble.Activate("¦w¦w", 1);
        }
    }

    private void ChangePosition()
    {
        transform.position = GridMovementManager.Instance.GetTargetPositionUpdateOccupiedTiles(transform.position, 0);
    }

    public void DebugInput(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }
}
