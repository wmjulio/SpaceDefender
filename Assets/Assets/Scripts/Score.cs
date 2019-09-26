using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    private int score;
    public float scoreMultiplier = 1;
    private bool isMultiplierActive;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int value)
    {
        if (isMultiplierActive)
        {
            value = Mathf.RoundToInt(value * scoreMultiplier);
        }

        score += value;
    }

    public int GetScore()
    {
        return score;
    }


    public void ActivateMultiplier(float multiplier, float duration)
    {
        if (scoreMultiplier < multiplier)
        {
            isMultiplierActive = true;
            scoreMultiplier = multiplier;
            Invoke("DeactivateMultiplier", duration);
        }
    }

    public void DeactivateMultiplier(float multiplier, float duration)
    {
        isMultiplierActive = false;
        scoreMultiplier = 1;
    }
}
