using GameBooster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKnockBack : CollisionDetector2D
{
    public Component shutdownComponent;
    private GameObject agressor;
    public float respawnTime = 5f;
    public float forceMultiplier = 10f;

    private string myTag;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (collisionEvent == CollisionEvent.Enter && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision))
        {
            if (CheckTags(col.gameObject))
            {
                agressor = col.gameObject;
                StartCoroutine(restartComponentFollowTouch());

                actions.Invoke(col.gameObject);
            }
        }
    }

    void disableComponents()
    {
        if (true == GetComponent<FollowTouch>().enabled)
        {
            GetComponent<FollowTouch>().enabled = false;
        }

        if (true == GetComponent<FaceMouse>().enabled)
        {
            GetComponent<FaceMouse>().enabled = false;
        }
    }

    void enableComponents()
    {
        if (false == GetComponent<FollowTouch>().enabled)
        {
            GetComponent<FollowTouch>().enabled = true;
        }

        if (false == GetComponent<FaceMouse>().enabled)
        {
            GetComponent<FaceMouse>().enabled = true;
        }
    }

    void knockBack()
    {
        Vector2 myVelocity;
        Vector2 aVelocity = agressor.GetComponent<Rigidbody2D>().velocity;

        myVelocity = aVelocity * forceMultiplier;

        this.GetComponent<Rigidbody2D>().AddForce(myVelocity );
    }

    IEnumerator restartComponentFollowTouch()
    {
        disableComponents();
        knockBack();
        yield return new WaitForSeconds(respawnTime);
        enableComponents();
    }
}
