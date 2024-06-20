using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflacter : Block
{
    private List<Snowball_1> snowball_1s;
    [SerializeField] Vector2 direction;
    [SerializeField] snowballState holderState;

    public override void GetHit (Snowball_1 snowball_1)
    {
        snowball_1.Set(direction,holderState);
    }
}
