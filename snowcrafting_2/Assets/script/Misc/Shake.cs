using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] bool test = false;
    [SerializeField] float duration;
    [SerializeField] AnimationCurve curve;

    private void Update()
    {
        if (test)
        {
            StartShake();
            test = false;
        }
    }

    public void StartShake()
    {
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        Vector2 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strangth = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitCircle*strangth;
            yield return null;
        }

        transform.position = startPosition;
    }
}
