using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour, IHitable
{
    protected Animator anim;
    [SerializeField] int enemyIndex;
    [SerializeField] VoidSOSignal enemyKnockSignal;

    [Header("Movement")]
    [SerializeField] public enemyState currentState;
    private Vector2 currentDestination;
    [SerializeField] private float movementSpeed;

    [Header("MovementTime")]
    protected float currentMovementTime;
    protected float MovementTime;
    [SerializeField] float idleTimeMin;
    [SerializeField] float idleTimeMax;
    [SerializeField] float knockTime;

    [Header("MovementProbability")]
    [SerializeField] int idle_idle;
    [SerializeField] int idle_move;
    [SerializeField] int idle_attack;

    [SerializeField] int move_idle;
    [SerializeField] int move_move;
    [SerializeField] int move_attack;

    [SerializeField] int attack_idle;
    [SerializeField] int attack_move;
    [SerializeField] int attack_attack;

    [SerializeField] int stun_idle;
    [SerializeField] int stun_move;
    [SerializeField] int stun_attack;


    [Header("Animation Parameters")]
    // Bool
    private bool isMoving;
    protected bool isAttacking;
    private bool isStunning;
    private bool isKnocking;

    [Header("Test")]
    [SerializeField] bool Hit;



    private void Awake()
    {
        Idle();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ResetAnimationParameters();

        Movement();

        UpdateAnimatiorParameters();

        TestUpdate();
    }


    private void Movement()
    {
        if(currentState == enemyState.idle)
        {
            Idling();
        }
        else if(currentState == enemyState.move)
        {
            Moving();
        }
        else if (currentState == enemyState.attack)
        {
            Attacking();
        }
        else if (currentState == enemyState.stun)
        {
            Stunning();
        }
        else if (currentState == enemyState.knock)
        {
            Knocking();
        }
    }

    private void TestUpdate()
    {
        if(Hit == true)
        {
            GetHit();
            Hit = false;
        }
    }


    //////////////////////////////////////////////////////////// CHANGE STATE ///////////////////////////////////////////////////////////////////////
    protected virtual void Idle()
    {
        SetMovementTime(Random.Range(idleTimeMin, idleTimeMax));
        MovementTimerReset();
        ChangeState(enemyState.idle);
    }
    private void Move()
    {
        preMoveSettings();
        ChangeState(enemyState.move);
    }
    protected virtual void preMoveSettings()
    {
        currentDestination = GridMovementManager.Instance.GetTargetPositionUpdateOccupiedTiles(transform.position, enemyIndex);
    }

    private void Attack()
    {
        PreAttackSettings();
        MovementTimerReset();
        ChangeState(enemyState.attack);
    }
    protected virtual void PreAttackSettings()
    {

    }
    private void Stun()
    {
        MovementTimerReset();
        ChangeState(enemyState.stun);
    }
    protected void Knock()
    {
        MovementTimerReset();
        ChangeState(enemyState.knock);
        enemyKnockSignal.Raise();
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }

    protected virtual void ChangeState(enemyState toState)
    {
        if (currentState != toState)
        {
            currentState = toState;
        }
    }

    //////////////////////////////////////////////////////////// UPDATING STATE /////////////////////////////////////////////////////////////////////
    private void Idling()
    {
        MovementTimerCount();
        if (currentMovementTime >= MovementTime)
        {
            ChooseWhatToDo();
        }
    }
    private void Moving()
    {
        isMoving = true;
        transform.position = Vector2.MoveTowards(transform.position, currentDestination, movementSpeed * Time.deltaTime);
        if((Vector2)transform.position == currentDestination)
        {
            ChooseWhatToDo();
        }
    }
    protected virtual void Attacking()
    {
        isAttacking = true;
        // Attack stuff
        ChooseWhatToDo();
    }
    private void Stunning()
    {
        isStunning = true;
        MovementTimerCount();
        if (currentMovementTime >= Settings.stunTime)
        {
            ChooseWhatToDo();
        }
    }
    private void Knocking()
    {
        isKnocking = true;
        MovementTimerCount();
        if(currentMovementTime >= knockTime)
        {

        }
    }



    //////////////////////////////////////////////////////////// STATE DECISION /////////////////////////////////////////////////////////////////////
    protected void ChooseWhatToDo()
    {
        int temp = Random.Range(1, 101);

        if (currentState == enemyState.idle)
        {
            if (temp <= idle_idle)
            {
                Idle();
            }
            else if (temp <= idle_idle + idle_move)
            {
                Move();
            }
            else if (temp <= idle_idle + idle_move + idle_attack)
            {
                Attack();
            }
            else
            {
                Debug.Log("dont know what to do");
            }
        }

        else if (currentState == enemyState.move)
        {
            if (temp <= move_idle)
            {
                Idle();
            }
            else if (temp <= move_idle + move_move)
            {
                Move();
            }
            else if (temp <= move_idle + move_move + move_attack)
            {
                Attack();
            }
            else
            {
                Debug.Log("dont know what to do");
            }
        }

        else if (currentState == enemyState.attack)
        {
            if (temp <= attack_idle)
            {
                Idle();
            }
            else if (temp <= attack_idle + attack_move)
            {
                Move();
            }
            else if (temp <= attack_idle + attack_move + attack_attack)
            {
                Attack();
            }
            else
            {
                Debug.Log("dont know what to do");
            }
        }

        else if (currentState == enemyState.stun)
        {
            if (temp <= stun_idle)
            {
                Idle();
            }
            else if (temp <= stun_idle + stun_move)
            {
                Move();
            }
            else if (temp <= stun_idle + stun_move + stun_attack)
            {
                Attack();
            }
            else
            {
                Debug.Log("dont know what to do");
            }
        }
    }


    //////////////////////////////////////////////////////////// GET HIT ////////////////////////////////////////////////////////////////////////////
    public virtual void GetHit()
    {
        if (currentState == enemyState.idle || currentState == enemyState.attack || currentState == enemyState.move)
        {
            Stun();
        }
        else if (currentState == enemyState.stun)
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



    //////////////////////////////////////////////////////////// methods //////////////////////////////////////////////////////////////////////////////

    protected void SetCurrentDestination(Vector2 destination)
    {
        currentDestination = destination;
    }
    protected enemyState GetCurrentState()
    {
        return currentState;
    }


    //////////////////////////////////////////////////////////////// ANIMATION //////////////////////////////////////////////////////////////////////
    protected virtual void ResetAnimationParameters()
    {
        isMoving = false;
        isAttacking = false;
        isStunning = false;
        isKnocking = false;
    }
    protected virtual void UpdateAnimatiorParameters()
    {
        anim.SetBool(Settings.isMoving, isMoving);
        anim.SetBool(Settings.isAttacking, isAttacking);
        anim.SetBool(Settings.isStunning, isStunning);
        anim.SetBool(Settings.isKnocking, isKnocking);
    }
}
