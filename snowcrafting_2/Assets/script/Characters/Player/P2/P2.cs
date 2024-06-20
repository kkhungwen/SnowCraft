using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : Player,IBlockHolder
{
    [SerializeField] Shield shield;

    [Header("Animation Parameters")]
    [SerializeField] float attackInterval_1;
    private bool isAttacking_1;

    protected override void PreAttackSettings()
    {
        isAttacking_1 = false;
    }

    protected override void Attacking()
    {
        base.Attacking();

        if (isAttacking_1 == false && currentMovementTime >= attackInterval_1)
        {
            isAttacking_1 = true;
            ActivateBlock();
        }
        else
        {
            MovementTimerCount();
        }
    }

    protected override void Charging()
    {
        base.Charging();
    }

    private void ActivateBlock()
    {
        shield.Activate();
    }

    private void DeActivateBlock()
    {
        shield.DeActivate();
    }

    protected override void ChangeState(playerState toState)
    {
        if(currentState == playerState.attack)
        {
            DeActivateBlock();
        }
        base.ChangeState(toState);
    }
}
