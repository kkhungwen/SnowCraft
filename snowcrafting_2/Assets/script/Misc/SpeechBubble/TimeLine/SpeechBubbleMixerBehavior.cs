using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBubbleMixerBehaviour : PlayableBehaviour
{
    bool isCalled = true;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        SpeechBubble speechBubble = playerData as SpeechBubble;
        if(speechBubble == null)
        {
            return;
        }

        bool isEmptyClip = true;
        int inputCount = playable.GetInputCount();
        for(int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if(inputWeight > 0)
            {
                isEmptyClip = false;
                isCalled = false;
            }
        }
        if(isEmptyClip)
        {
            if (!isCalled)
            {
                speechBubble.PauseDirector();
                isCalled = true;
            }
        }
    }
}
