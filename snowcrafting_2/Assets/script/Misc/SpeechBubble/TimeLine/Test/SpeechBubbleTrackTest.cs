using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[TrackColor(255/255f, 255 / 255f, 255 / 255f)]
[TrackClipType(typeof(SpeechBubbleClipTest))]
[TrackBindingType(typeof(SpeechBubbleTest))]
public class SpeechBubbleTrackTest : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SpeechBubbleMixerBehaviourTest>.Create(graph, inputCount);
    }
}
