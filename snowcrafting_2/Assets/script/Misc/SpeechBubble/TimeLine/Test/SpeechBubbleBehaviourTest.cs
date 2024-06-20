using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBubbleBehaviourTest : PlayableBehaviour
{
    public SOSpeech speech;
    bool isCalledWhenPlayed;
    float duration;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        isCalledWhenPlayed = false;
        duration = (float)playable.GetDuration();
    }
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        SpeechBubbleTest actor = playerData as SpeechBubbleTest;
        if (isCalledWhenPlayed == false)
        {
            actor.Activate(speech, duration);
            isCalledWhenPlayed = true;
        }
        actor.PrintingTextCutScene(info.deltaTime);
    }
}
