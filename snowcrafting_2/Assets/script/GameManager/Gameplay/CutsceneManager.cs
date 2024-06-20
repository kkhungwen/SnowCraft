using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.InputSystem;

public class CutsceneManager : SingletonMonoBehaviour<CutsceneManager>
{
    private InputManager inputManager;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private cutsceneState currentState;
    [SerializeField] private VoidSOSignal unpauseCutsceneSignal;
    [SerializeField] private VoidSOSignal finishPlayingSignal;
    [SerializeField] private bool isFinishPlaying;




    protected override void Awake()
    {
        base.Awake();
        inputManager = InputManager.Instance;
    }
    private void OnEnable()
    {
        inputManager.OnPlayCutscene_performed += InputUnpauseDirector;
    }

    private void OnDisable()
    {
        inputManager.OnPlayCutscene_performed -= InputUnpauseDirector;
    }

    private void Update()
    {
        if (isFinishPlaying)
        {
            FinishPlaying();
            isFinishPlaying = false;
        }
    }

    public void SetTimeline(TimelineAsset timeline)
    {
        director.playableAsset = timeline;
    }

    public void PlayDirector()
    {
        director.Play();
        currentState = cutsceneState.play;
    }

    public void StopDirector()
    {
        director.Stop();
        currentState = cutsceneState.stop;
    }

    private void FinishPlaying()
    {
        StopDirector();
        finishPlayingSignal.Raise();
    }

    public void PauseDirectorWaitForInput()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
        currentState = cutsceneState.pauseWaitForInput;
    }

    public void UnpauseDirector()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
        unpauseCutsceneSignal.Raise();
        currentState = cutsceneState.play;
    }

    public void InputUnpauseDirector(InputAction.CallbackContext context)
    {
        if(currentState == cutsceneState.pauseWaitForInput)
        {
            UnpauseDirector();
        }
    }
}
