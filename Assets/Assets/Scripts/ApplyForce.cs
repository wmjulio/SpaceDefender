using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public float thrust, min, max;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(
            Random.Range(min, max),
            Random.Range(min, max)
            );
        rb.AddForce(movement * thrust);
    }
}
