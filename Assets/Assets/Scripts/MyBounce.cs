using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBounce : MonoBehaviour
{
    public float bounciness;
    public float maxVelocity;

    // Update is called once per frame
    public void Bounce()
    {
        Vector2 rbVelocity = GetComponent<Rigidbody2D>().velocity;

        rbVelocity *= -1;

        if (
            Mathf.Abs(rbVelocity.x) < maxVelocity
            && Mathf.Abs(rbVelocity.y) < maxVelocity
        )
        {
            rbVelocity *= bounciness;
        } else
        {
            rbVelocity = (rbVelocity / rbVelocity) * maxVelocity;
        }

        GetComponent<Rigidbody2D>().velocity = rbVelocity;
    }
}
