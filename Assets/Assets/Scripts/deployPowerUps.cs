using GameBooster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class deployPowerUps : MonoBehaviour
{
    public GameObject[] powerUps;
    public float respawnTime = 1.0f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
                )
            );

        StartCoroutine(meteorWave());
    }

    private void spawnMeteor()
    {
        GameObject prefab = powerUps[(int)Random.Range(0f, (float)powerUps.Length)];
        GameObject meteor = Instantiate(prefab) as GameObject;

        float objectWidth = meteor.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float objectHeight = meteor.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        meteor.transform.position = new Vector2(
            Random.Range(-screenBounds.x + objectWidth, screenBounds.x - objectWidth),
            Random.Range(-screenBounds.y + objectHeight, screenBounds.y - objectHeight)
            );
    }

    IEnumerator meteorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteor();
        }
    }
}
