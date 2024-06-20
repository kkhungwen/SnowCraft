using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3 : Enemy,IBlockHolder
{
    [Header("Attack")]
    [SerializeField] private float maxAttackTime;
    [SerializeField] private float attackInterval_1;

    [Header("Animation Parameters")]
    private bool isAttacking_1;

    [Header("Block")]
    [SerializeField] private Reflacter reflacter;

    protected override void PreAttackSettings()
    {
        isAttacking_1 = false;
    }

    protected override void Attacking()
    {
        isAttacking = true;
        MovementTimerCount();

        if (isAttacking_1 == false && currentMovementTime >= attackInterval_1)
        {
            isAttacking_1 = true;
            ActivateBlock();
        }
        else if(currentMovementTime >= maxAttackTime)
        {
            DeActivateBlock();
            ChooseWhatToDo();
        }
    }

    private void ActivateBlock()
    {
        reflacter.Activate();
    }

    private void DeActivateBlock()
    {
        reflacter.DeActivate();
    }

    public override void GetHit()
    {
        DeActivateBlock();
        base.GetHit();
    }

    //////////////////////////////////////////////////////////////// ANIMATION ////////////////////////////////////////////////////////////////////////
    protected override void ResetAnimationParameters()
    {
        base.ResetAnimationParameters();
    }

    protected override void UpdateAnimatiorParameters()
    {
        base.UpdateAnimatiorParameters();
    }
}
