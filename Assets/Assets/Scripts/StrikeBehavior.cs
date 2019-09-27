using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikeBehavior : MonoBehaviour
{

    Vector3 initPos;
    public Vector3 minScale, maxScale;
    public float speed = 5f;
    public float duration = 2f;
    public GameObject strikeHolder;
    public Button btnStrike;

    Energy strikeEnergy;
    // Start is called before the first frame update
    
    void Start()
    {
        initPos = transform.position;
        strikeEnergy = strikeHolder.GetComponent<Energy>();
        btnStrike.enabled = false;
    }

    public void StartStrike()
    {
        transform.position = Vector3.zero;
        StartCoroutine(StartLerping());
    }

    private void Update()
    {
        if (strikeEnergy.GetEnergy() == strikeEnergy.maxEnergy)
        {
            btnStrike.enabled = true;
        }
    }


    IEnumerator StartLerping()
    {
        // lerp up
        yield return RepeatLerp(minScale, maxScale, duration);
        yield return RepeatLerp(maxScale, minScale, duration);
        StopCoroutine(StartLerping());
        btnStrike.enabled = false;
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

}
