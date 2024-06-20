using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOSpeech: ScriptableObject
{
    [TextArea] public string speechString;
    public int speechBubbleIndexCode;
    public int fontSizeIndex;
    public bool isShake;
}
