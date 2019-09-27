using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int value;
    public float scoreMultiplier = 1;
    private bool isMultiplierActive;
    // Start is called before the first frame update
    void Start()
    {
        value = 0;
    }

    public void AddScore(int x)
    {
        if (isMultiplierActive)
        {
            x = Mathf.RoundToInt(x * scoreMultiplier);
        }
        value += x;
        // print(string.Concat("Adicionando: ", x.ToString(), "Novo valor: ", value.ToString()));
        print("Adicionando: " + x.ToString() + "Novo valor: " + value.ToString());
    }

    public int GetScore()
    {
        return value;
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
