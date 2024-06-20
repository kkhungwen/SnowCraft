using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1test : Player
{
    [Header("Snow Ball")]
    [SerializeField] private Snowball_1 p1Snowball;
    [SerializeField] private float tempPower;
    [SerializeField] private float minPower;
    [SerializeField] private float maxPower;
    [SerializeField] private float fullChargeTime;
    [SerializeField] private float resist;
    [SerializeField] private float lifeTime;

    [Header("Animation Parameters")]
    [SerializeField] float attackTime;
    private bool isAttacking_1;

    protected override void PreChargeSettings()
    {
        base.PreChargeSettings();
        tempPower = minPower;
    }

    protected override void PreAttackSettings()
    {
        base.PreAttackSettings();
        SetMovementTime(attackTime);
        isAttacking_1 = false;
    }

    protected override void Attacking()
    {
        base.Attacking();
        MovementTimerCount();
        if(isAttacking_1 == false)
        {
            LaunchBall();
            isAttacking_1 = true;
        }
        else if (currentMovementTime >= MovementTime)
        {
            ChangeState(playerState.idle);
        }
    }

    private void LaunchBall()
    {
        Snowball_1 thisSnowball = Instantiate(p1Snowball, transform.position, Quaternion.identity);
        thisSnowball.Set(Vector2.up, tempPower, resist, lifeTime, snowballState.playerBall);
    }

    protected override void Charging()
    {
        base.Charging();
        if (tempPower < maxPower)
        {
            ////////can be optamized
            tempPower += Time.deltaTime * ((maxPower - minPower) / fullChargeTime);
        }
        else
        {
            tempPower = maxPower;
        }
    }
}
