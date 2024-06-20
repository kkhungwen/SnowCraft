/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class P1 : SingletonMonoBehaviour<P1> , ItouchControl, IHitable
{
    private Vector2 touchPosition;
    [SerializeField] private p1State currentState;
    Animator anim;
    [SerializeField] private Collider2D hurtBox;

    [Header("Movement")]
    private float currentMovementTime;

    [Header("Touch")]
    private Vector2 tapPositionTemp;

    [Header("Animation Parameters")]
    private bool isCharging;
    private bool isStunning;
    private bool isAttacking;
    private bool isKnocking;

    [Header("Snow Ball")]
    [SerializeField] private P1Snowball p1Snowball;
    [SerializeField] private float tempPower;
    [SerializeField] private float minPower;
    [SerializeField] private float maxPower;
    [SerializeField] private float fullChargeTime;
    [SerializeField] private float resist;
    [SerializeField] private float lifeTime;

    [Header("Test")]
    [SerializeField] bool Hit;


    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ResetAnimationParameters();

        Movement();

        UpdateAnimatiorParameters();
    }



    void Movement()
    {
        if (currentState == p1State.charge)
        {
            Charging();
        }

        else if(currentState == p1State.attack)
        {
            Attacking();
        }

        else if(currentState == p1State.stun)
        {
            Stunning();
        }

        else if(currentState == p1State.knock)
        {
            Knocking();
        }
    }



    //////////////////////////////////////////////////////////// UPDATING STATE /////////////////////////////////////////////////////////////////////

    void Attacking()
    {
        isAttacking = true;
        P1Snowball thisSnowball = Instantiate(p1Snowball,transform.position,Quaternion.identity);
        thisSnowball.Set(tempPower,resist,lifeTime);
        currentState = p1State.idle;
    }

    void Charging()
    {
        isCharging = true;
        transform.position = touchPosition;
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

    void Stunning()
    {
        isStunning = true;
        currentMovementTime -= Time.deltaTime;
        if (currentMovementTime <= 0)
        {
            isStunning = false;
            currentState = p1State.idle;
        }
    }

    void Knocking()
    {
        isKnocking = true;
    }



    //////////////////////////////////////////////////////////// CHANGE STATE ///////////////////////////////////////////////////////////////////////

    public void GetHit()
    {
        if(currentState == p1State.idle || currentState == p1State.attack || currentState == p1State.charge)
        {
            Stun();
        }
        else if(currentState == p1State.stun)
        {
            Knock();
        }
    }

    void Charge()
    {
        currentState = p1State.charge;
        tempPower = minPower;
    }

    void Attack()
    {
        currentState = p1State.attack;
    }

    void Stun()
    {
        currentMovementTime = Settings.stunTime;
        currentState = p1State.stun;
    }

    void Knock()
    {
        currentState = p1State.knock;
        hurtBox.enabled = false;
    }


    //////////////////////////////////////////////////////////////// TOUCH INPUT ///////////////////////////////////////////////////////////////////////

    public void BeganTouch()
    {
        Debug.Log("began");
        if (currentState == p1State.idle)
        {
            tapPositionTemp = transform.position;
            Charge();
        }
    }

    public void Touching(Vector2 touchPosition)
    {
        this.touchPosition = touchPosition;
    }

    public void EndTouch_Hold()
    {
        if (currentState == p1State.charge)
        {
            Attack();
        }
    }

    public void EndTouch_Tap()
    {
        if(currentState == p1State.charge)
        {
            transform.position = tapPositionTemp;
            Attack();
        }
    }


    //////////////////////////////////////////////////////////////// ANIMATION ////////////////////////////////////////////////////////////////////////

    private void ResetAnimationParameters()
    {
        isAttacking = false;
        isKnocking = false;
        isCharging = false;
        isStunning = false;
        isAttacking = false;
    }

    private void UpdateAnimatiorParameters()
    {
        anim.SetBool(Settings.isCharging, isCharging);

        anim.SetBool(Settings.isStunning, isStunning);

        anim.SetBool(Settings.isKnocking, isKnocking);

        if (isAttacking)
        {
            anim.SetTrigger(Settings.isAttacking);
        }
    }
}
*/