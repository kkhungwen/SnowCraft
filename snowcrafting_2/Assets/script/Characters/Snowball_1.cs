using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball_1 : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Vector2 direction;
    float power;
    float resist;
    bool isHit;
    [SerializeField] float lifeTime;
    [SerializeField] snowballState currentstate;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Launch();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHit)
        {
            IHitable hitable = other.GetComponent<IHitable>();
            if (hitable != null)
            {
                string otherTag = other.gameObject.tag;
                if(currentstate == snowballState.playerBall)
                {
                    if (otherTag == Settings.enemyLaunchableTag)
                    {
                        isHit = true;
                        hitable.GetHit(this);
                    }
                    else if (otherTag == Settings.enemyTag)
                    {
                        isHit = true;
                        hitable.GetHit();
                        Die();
                    }
                    else if (otherTag == Settings.playerBlockTag)
                    {
                        isHit = true;
                        Die();
                    }
                }
                else if (currentstate == snowballState.enemyBall)
                {
                    if (otherTag == Settings.playerLaunchableTag)
                    {
                        isHit = true;
                        hitable.GetHit(this);
                    }
                    if (otherTag == Settings.playerTag || otherTag == Settings.playerBlockTag)
                    {
                        isHit = true;
                        hitable.GetHit();
                        Die();
                    }
                }
            }
        }
    }

    void Launch()
    {
        myRigidbody.velocity = direction * power;
        power -= resist * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0 || power < 0)
        {
            Die();
        }
    }

    public void Set(Vector2 direction, float power, float resist, float lifeTime, snowballState snowballState)
    {
        currentstate = snowballState;
        isHit = false;
        this.direction = direction;
        this.power = power;
        this.resist = resist;
        this.lifeTime = lifeTime;
    }

    public void Set(Vector2 direction, snowballState snowballState)
    {
        currentstate = snowballState;
        isHit = false;
        this.direction = direction;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
