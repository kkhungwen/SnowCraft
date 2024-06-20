using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    [SerializeField] playerInputActionMapEnum currentActionMap;
    [SerializeField] playerInputActionMapEnum testActionMap;

    private PlayerInputAction playerInputAction;

    public delegate void PrimaryTouch_performedDelegate(InputAction.CallbackContext context);
    public event PrimaryTouch_performedDelegate OnPrimaryTouch_performed;
    public delegate void PrimaryTouch_canceledDelegate(InputAction.CallbackContext context);
    public event PrimaryTouch_canceledDelegate OnPrimaryTouch_canceled;

    public delegate void PlayCutScene_performedDelegate(InputAction.CallbackContext context);
    public event PlayCutScene_performedDelegate OnPlayCutscene_performed;

    public delegate void Test_performedDelegate(InputAction.CallbackContext context);
    public event Test_performedDelegate OnTest_performed;
    public delegate void Test_startedDelegate(InputAction.CallbackContext context);
    public event Test_startedDelegate OnTest_started;
    public delegate void Test_canceledDelegate(InputAction.CallbackContext context);
    public event Test_canceledDelegate OnTest_canceled;


    protected override void Awake()
    {
        base.Awake();

        playerInputAction = new PlayerInputAction();
        currentActionMap = playerInputActionMapEnum.none;

        playerInputAction.InGame.PrimaryTouch.performed += PrimaryTouch_performed;
        playerInputAction.InGame.PrimaryTouch.canceled += PrimaryTouch_canceled;

        playerInputAction.Cutscene.PlayCutscene.performed += PlayCutscene_performed;

        playerInputAction.Cutscene.Test.started += Test_started;
        playerInputAction.Cutscene.Test.performed += Test_performed;
        playerInputAction.Cutscene.Test.canceled += Test_canceled;

    }

    private void Update()
    {
        //test
        if (currentActionMap != testActionMap)
        {
            SwitchActionMap(testActionMap);
        }
    }

    public void SwitchActionMap(playerInputActionMapEnum switchToActionMap)
    {
        if (currentActionMap != switchToActionMap)
        {
            foreach (InputActionMap i in playerInputAction.asset.actionMaps)
            {
                i.Disable();
            }
            playerInputAction.asset.actionMaps[(int)switchToActionMap].Enable();
            currentActionMap = switchToActionMap;
        }
    }

    private void PrimaryTouch_canceled(InputAction.CallbackContext context)
    {
        if(OnPrimaryTouch_canceled != null)
        {
            OnPrimaryTouch_canceled(context);
        }
    }

    private void PrimaryTouch_performed(InputAction.CallbackContext context)
    {
        if (OnPrimaryTouch_performed != null)
        {
            OnPrimaryTouch_performed(context);
        }
    }

    private void PlayCutscene_performed(InputAction.CallbackContext context)
    {
        if (OnPlayCutscene_performed != null)
        {
            OnPlayCutscene_performed(context);
        }
    }

    private void Test_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("TEST CANCELED");
        if (OnTest_canceled != null)
        {
            OnTest_canceled(context);
        }
    }

    private void Test_performed(InputAction.CallbackContext context)
    {
        Debug.Log("TEST PERFORMED");
        if (OnTest_performed != null)
        {
            OnTest_performed(context);
        }
    }

    private void Test_started(InputAction.CallbackContext context)
    {
        Debug.Log("TEST STARTED");
        if (OnTest_started != null)
        {
            OnTest_started(context);
        }
    }
}
