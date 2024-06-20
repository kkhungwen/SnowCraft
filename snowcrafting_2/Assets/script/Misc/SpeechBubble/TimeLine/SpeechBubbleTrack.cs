using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[TrackColor(255/255f, 255 / 255f, 255 / 255f)]
[TrackClipType(typeof(SpeechBubbleClip))]
[TrackBindingType(typeof(SpeechBubble))]
public class SpeechBubbleTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SpeechBubbleMixerBehaviour>.Create(graph, inputCount);
    }
}
