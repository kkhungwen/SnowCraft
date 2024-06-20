using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBubbleClip : PlayableAsset
{
    private SpeechBubbleBehaviour template = new SpeechBubbleBehaviour();
    [TextArea]public string speechString;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpeechBubbleBehaviour>.Create(graph, template);
        SpeechBubbleBehaviour clone = playable.GetBehaviour();
        clone.speechString = this.speechString;
        return playable;  
    }
}
