using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Enemy, IHitable
{
    [Header("tower1 Attack")]
    [SerializeField] private float attackInterval_1;
    [SerializeField] private float attackInterval_2;
    [SerializeField] private int attackCountMax;
    [SerializeField] private int attackCount = 0;


    [Header("Snow Ball")]
    [SerializeField] private Snowball_1 towerSnowball;
    [SerializeField] private float Power;
    [SerializeField] private float resist;
    [SerializeField] private float lifeTime;

    [Header("tower1 Animation Parameters")]
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
            attackCount++;
            if (attackCount >= attackCountMax)
            {
                Knock();
            }
            else
            {
                ChooseWhatToDo();
            }
        }
    }

    private void LaunchBall()
    {
        Snowball_1 thisSnowball = Instantiate(towerSnowball, transform.position, Quaternion.identity);
        thisSnowball.Set(Vector2.down, Power, resist, lifeTime, snowballState.enemyBall);
    }

    public override void GetHit()
    {
        Knock();
    }

    //////////////////////////////////////////////////////////////// ANIMATION ////////////////////////////////////////////////////////////////////////


    protected override void UpdateAnimatiorParameters()
    {
        base.UpdateAnimatiorParameters();
        anim.SetBool(Settings.isAttacking_1, isAttacking_1);
    }
}
