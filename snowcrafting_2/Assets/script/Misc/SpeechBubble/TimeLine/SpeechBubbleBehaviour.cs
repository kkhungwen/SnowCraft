using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBubbleBehaviour : PlayableBehaviour
{
    public string speechString;
    bool isCalledWhenPlayed;
    float duration;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        isCalledWhenPlayed = false;
        duration = (float)playable.GetDuration();
    }
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        SpeechBubble actor = playerData as SpeechBubble;
        if (isCalledWhenPlayed == false)
        {
            actor.Activate(speechString, duration);
            isCalledWhenPlayed = true;
        }
        actor.PrintingTextCutScene(info.deltaTime);
    }
}
