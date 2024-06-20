using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOSpeechBubble : ScriptableObject
{
    public int indexCode;
    public string speechBubbleName;
    public Sprite bubbleHeadSprite;
    public Sprite backGroundSprite;
    public Vector2 bubbleImageOffset;
    public float outLineOffset;
    public Sprite outLineDecoImage;
}
