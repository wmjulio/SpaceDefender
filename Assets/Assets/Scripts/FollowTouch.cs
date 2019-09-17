using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    public float minDistance = 0.09f;

    public Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, target;

    bool isMoving = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

        // Prints number of fingers touching the screen
        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            print("User has " + fingerCount + " finger(s) touching the screen");
        }
        

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                target = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(target.x * moveSpeed, target.y * moveSpeed);
            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
        {
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
    }
    /*
    void FixedUpdate()
    {
        //Find direction
        Vector3 dir = (target.transform.position - rb.transform.position).normalized;
        //Check if we need to follow object then do so 
        if (Vector3.Distance(target.transform.position, rb2d.transform.position) > minDistance)
        {
            rb.MovePosition(rb2d.transform.position + dir * speed * Time.fixedDeltaTime);
        }
    }
    */
}
