using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLerper : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public float speed = 2f;
    public float duration = 5f;

    private Coroutine routine;
    private Vector3 stepScale;
    // Start is called before the first frame update
    IEnumerator Start()
    {
       // minScale = transform.localScale;

        while (false)
        {
            yield return RepeatLerp(minScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
        }
    }

    public void IncreaseScale(float percentualIncrease)
    {
        percentualIncrease = percentualIncrease / 100;
        stepScale = transform.localScale + (transform.localScale * percentualIncrease);
        if (isAGreaterThanB(maxScale, stepScale))
        {
            routine = StartCoroutine(RepeatLerp(transform.localScale, stepScale, duration));
        }
        else
        {
            stopRoutine();
        }
    }

    public void DecreaseScale(float percentualDecrease)
    {
        

        percentualDecrease = percentualDecrease / 100;
        stepScale = transform.localScale - (transform.localScale * percentualDecrease);
        if (isAGreaterThanB(stepScale, minScale))
        {
            routine = StartCoroutine(RepeatLerp(transform.localScale, stepScale, duration));
        }
        else
        {
            stopRoutine();
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void stopRoutine()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
    }

    private bool isAGreaterThanB(Vector3 a, Vector3 b)
    {
        if (
            a.x > b.x
            && a.y > b.y
            && a.z > b.z
        )
        {
            return true;
        }
        return false;
    }
}
