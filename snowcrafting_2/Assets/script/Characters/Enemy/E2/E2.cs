using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2 : Enemy
{
    [Header("Attack")]
    [SerializeField] private float attackInterval_1;
    [SerializeField] private float attackInterval_2;

    [Header("Tower")]
    [SerializeField] private Enemy tower;

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
            BuildTower();
        }
        else if (currentMovementTime >= attackInterval_1 + attackInterval_2)
        {
            isAttacking = false;
            ChooseWhatToDo();
        }
    }

    private void BuildTower()
    {
        Enemy thisTower = Instantiate(tower, transform.position,Quaternion.identity);
    } 
}
