using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour,IHitable
{
    [SerializeField] protected IBlockHolder holder;
    [SerializeField] protected Animator anim;

    private void Awake()
    {
        holder = gameObject.transform.parent.gameObject.GetComponent<IBlockHolder>();
        anim = GetComponent<Animator>();
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        SetUp();
    }

    protected virtual void SetUp()
    {

    }

    public virtual void GetHit()
    {

    }

    public virtual void GetHit(Snowball_1 snowball)
    {

    }
}
