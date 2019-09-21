using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public float speed;
    public string element;
    public float minDistance;

    private Transform target;
    private float currentDistance;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gObject = GameObject.FindGameObjectWithTag(element);
        if (gObject != null)
        {
            target = gObject.GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            currentDistance = (target.position - rb.transform.position).magnitude;

            if (currentDistance > minDistance)
            {
                Vector3 dir = (target.position - rb.transform.position).normalized;
                rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);


                Vector2 direction = new Vector2(
                    target.position.x - rb.transform.position.x,
                    target.position.y - rb.transform.position.y
                );

                transform.up = direction;
            }
        }
    }
}
