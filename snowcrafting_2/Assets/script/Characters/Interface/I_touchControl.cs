using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItouchControl 
{
    void BeganTouch();


    void Touching(Vector2 touchPosition);


    void EndTouch_Hold();


    void EndTouch_Tap();

}
