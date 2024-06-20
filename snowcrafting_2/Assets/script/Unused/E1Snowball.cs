/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Snowball : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    float power;
    float resist;
    [SerializeField]float lifeTime;

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
        if(other.GetComponent<P1>() != null)
        {
            other.GetComponent<P1>().GetHit();
            Destroy(gameObject);
        }
    }

    void Launch()
    {
        myRigidbody.velocity = new Vector2(0, -1 * power);
        power -= resist * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0 || power <0)
        {
            Destroy(gameObject);
        }
    }

    public void Set(float power, float resist, float lifeTime)
    {
        this.power = power;
        this.resist = resist;
        this.lifeTime = lifeTime;
    }
}
*/