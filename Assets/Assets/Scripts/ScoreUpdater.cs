using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    ScoreKeeper sk;
    public float multiplier = 2;
    public float duration = 1;
    // Start is called before the first frame update
    void Start()
    {
        sk = GameObject.FindGameObjectWithTag("MyGC").GetComponent<ScoreKeeper>();
    }
    public void addScore(int value)
    {
        sk.AddScore(value);
    }

    public void SetMultiplier(float m)
    {
        multiplier = m;
    }

    public void SetDuration(int d)
    {
        duration = d;
    }

    public void StartBonuses()
    {
        sk.ActivateMultiplier(multiplier, duration);
    }
}
