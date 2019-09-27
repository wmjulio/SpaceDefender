using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{

    public Text scoreText;

    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("MyGC").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}
