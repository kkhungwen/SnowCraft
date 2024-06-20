using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class E1 : Enemy
{
    [Header("Attack")]
    [SerializeField] private float attackInterval_1;
    [SerializeField] private float attackInterval_2;
    

    [Header("Snow Ball")]
    [SerializeField] private Snowball_1 e1Snowball;
    [SerializeField] private float Power;
    [SerializeField] private float resist;
    [SerializeField] private float lifeTime;

    [Header("Animation Parameters")]
    private bool isAttacking_1;



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
            LaunchBall();
        }
        else if (currentMovementTime >= attackInterval_1 + attackInterval_2)
        {
            isAttacking = false;
            ChooseWhatToDo();
        }
    }

    private void LaunchBall()
    {
        Snowball_1 thisSnowball = Instantiate(e1Snowball, transform.position, Quaternion.identity);
        thisSnowball.Set(Vector2.down, Power, resist, lifeTime, snowballState.enemyBall);
    }

    //////////////////////////////////////////////////////////////// ANIMATION ////////////////////////////////////////////////////////////////////////
    protected override void ResetAnimationParameters()
    {
        base.ResetAnimationParameters();
    }

    protected override void UpdateAnimatiorParameters()
    {
        base.UpdateAnimatiorParameters();
        anim.SetBool(Settings.isAttacking_1, isAttacking_1);
    }
}
