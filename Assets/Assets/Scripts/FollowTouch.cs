using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    public float minDistance = 0.09f;

    private Rigidbody2D rb;

    Touch touch;
    Vector3 touchPosition, target;

    float previousDistanceToTouchPos;
    float currentDistanceToTouchPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            if (
                touch.phase == TouchPhase.Began 
                || touch.phase == TouchPhase.Moved 
                || touch.phase == TouchPhase.Stationary
            ) {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;

                currentDistanceToTouchPos = (touchPosition - rb.transform.position).magnitude;
            }
        }
        
        if (currentDistanceToTouchPos > minDistance)
        {
            currentDistanceToTouchPos = (touchPosition - rb.transform.position).magnitude;
            Vector3 dir = (touchPosition - rb.transform.position).normalized;
            rb.MovePosition(rb.transform.position + dir * moveSpeed * Time.fixedDeltaTime);
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
