using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public float speed;
    public string element;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gObject = GameObject.FindGameObjectWithTag(element);
        if (gObject != null)
        {
            target = gObject.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
