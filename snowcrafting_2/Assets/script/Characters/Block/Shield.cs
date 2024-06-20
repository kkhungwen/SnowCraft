using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Block
{
    [SerializeField] int maxHP;
    [SerializeField] int HP;

    protected override void SetUp()
    {
        HP = maxHP;
    }

    public override void GetHit()
    {
        HP--;
        anim.SetTrigger(Settings.block_hp_decrease);
        if (HP<= 0)
        {
            holder.GetHit();
        }
    }
}
