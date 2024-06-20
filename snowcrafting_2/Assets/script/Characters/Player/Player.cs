using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour , ItouchControl, IHitable
{
    [SerializeField] protected playerState currentState;
    private Vector2 touchPosition;
    Animator anim;
    [SerializeField] private Collider2D hurtBox;

    [Header("Movement")]
    protected float currentMovementTime;
    protected float MovementTime;

    [Header("Touch")]
    private Vector2 tapPositionTemp;

    [Header("Animation Parameters")]
    private bool isCharging;
    private bool isStunning;
    private bool isAttacking;
    private bool isKnocking;

    [Header("Test")]
    [SerializeField] bool Hit;


    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ResetAnimationParameters();

        Movement();

        UpdateAnimatiorParameters();

        ///////////////////////////////////////////test///////////////////////////////////////
        if (Hit == true)
        {
            GetHit();
            Hit = false;
        }
        ///////////////////////////////////////////test///////////////////////////////////////
    }



    void Movement()
    {
        if (currentState == playerState.charge)
        {
            Charging();
        }

        else if (currentState == playerState.attack)
        {
            Attacking();
        }

        else if (currentState == playerState.stun)
        {
            Stunning();
        }

        else if (currentState == playerState.knock)
        {
            Knocking();
        }
    }



    //////////////////////////////////////////////////////////// UPDATING STATE /////////////////////////////////////////////////////////////////////

    protected virtual void Attacking()
    {
        isAttacking = true;
        //
    }

    protected virtual void Charging()
    {
        isCharging = true;
        transform.position = touchPosition;
        //
    }

    void Stunning()
    {
        isStunning = true;
        MovementTimerCount();
        if (currentMovementTime >= MovementTime)
        {
            ChangeState(playerState.idle);
        }
    }

    void Knocking()
    {
        isKnocking = true;
    }



    //////////////////////////////////////////////////////////// CHANGE STATE ///////////////////////////////////////////////////////////////////////

    void Charge()
    {
        PreChargeSettings();
        MovementTimerReset();
        ChangeState(playerState.charge);
    }

    void Attack()
    {
        PreAttackSettings();
        MovementTimerReset();
        ChangeState(playerState.attack);
    }
    protected virtual void PreAttackSettings()
    {

    }

    protected virtual void PreChargeSettings()
    {

    }

    void Stun()
    {
        SetMovementTime(Settings.stunTime);
        MovementTimerReset();
        ChangeState(playerState.stun);
    }

    void Knock()
    {
        hurtBox.enabled = false;
        ChangeState(playerState.knock);
    }

    protected virtual void ChangeState(playerState toState)
    {
        if(currentState != toState)
        {
            currentState = toState;
        }
    }


    //////////////////////////////////////////////////////////// Get Hit //////////////////////////////////////////////////////////////////////////////
    public void GetHit()
    {
        if (currentState == playerState.idle || currentState == playerState.attack || currentState == playerState.charge)
        {
            Stun();
        }
        else if (currentState == playerState.stun)
        {
            Knock();
        }
    }

    public void GetHit(Snowball_1 snowball_1)
    {

    }

    //////////////////////////////////////////////////////////// TIMER //////////////////////////////////////////////////////////////////////////////
    private void MovementTimerReset()
    {
        currentMovementTime = 0;
    }
    protected void MovementTimerCount()
    {
        currentMovementTime += Time.deltaTime;
    }
    protected void SetMovementTime(float time)
    {
        MovementTime = time;
    }


    //////////////////////////////////////////////////////////////// TOUCH INPUT ///////////////////////////////////////////////////////////////////////

    public void BeganTouch()
    {
        if (currentState == playerState.idle || currentState == playerState.attack)
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
        if (currentState == playerState.charge)
        {
            Attack();
        }
    }

    public void EndTouch_Tap()
    {
        if (currentState == playerState.charge)
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

        anim.SetBool(Settings.isAttacking, isAttacking);
    }

    //////////////////////////////////////////////////////////////// Methods ////////////////////////////////////////////////////////////////////////

    protected playerState GetCurrentState()
    {
        return currentState;
    }
}