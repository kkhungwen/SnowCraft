using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchControlScript : MonoBehaviour
{
    private InputManager inputManager;
    private Camera mainCamera;
    private ItouchControl beControl;
    [SerializeField]private bool isTouching;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnPrimaryTouch_performed += PrimaryTouchPresssed;
        inputManager.OnPrimaryTouch_canceled += PrimaryTouchEnded;
    }

    private void OnDisable()
    {
        inputManager.OnPrimaryTouch_performed -= PrimaryTouchPresssed;
        inputManager.OnPrimaryTouch_canceled -= PrimaryTouchEnded;
    }

    private void Update()
    {
        PrimaryTouchHoldUpdate();
    }

    private void PrimaryTouchPresssed(InputAction.CallbackContext context)
    {
        Debug.Log("press");
        Vector2 touchPosition = mainCamera.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());

        RaycastHit2D hit;
        if(Physics2D.Raycast(touchPosition,Vector2.zero,0,64))
        {
            hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            Debug.Log(hit.collider.gameObject);
            beControl = hit.collider.GetComponentInParent<ItouchControl>();
            if(beControl!= null)
            {
                beControl.BeganTouch();
                isTouching = true;
            }
        }
    }

    private void PrimaryTouchHoldUpdate()
    {
        if (isTouching)
        {
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());
            beControl.Touching(touchPosition);
        }
    }

    private void PrimaryTouchEnded(InputAction.CallbackContext context)
    {
        if (isTouching)
        {
            beControl.EndTouch_Hold();
            beControl = null;
            isTouching = false;
        }
    }
}
