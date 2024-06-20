using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBubbleClipTest : PlayableAsset
{
    private SpeechBubbleBehaviourTest template = new SpeechBubbleBehaviourTest();
    public SOSpeech speech;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpeechBubbleBehaviourTest>.Create(graph, template);
        SpeechBubbleBehaviourTest clone = playable.GetBehaviour();
        clone.speech = this.speech;
        return playable;  
    }
}
