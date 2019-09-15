using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterToDeath : MonoBehaviour
{

    public float timeToDie;
    public string tag;
    private float timer;
    private bool canCount;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToDie;
        canCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            if (timer <= 0.0f)
            {
                GameObject elemento = GameObject.FindGameObjectWithTag(tag);
                Destroy(elemento);
                stopCount();
            }

            timer -= Time.deltaTime;
        }
    }

    public void startCount()
    {
        canCount = true;
        print("Ligou");
    }

    public void stopCount()
    {
        canCount = false;
        timer = timeToDie;
        print("Desligou");
    }
}
