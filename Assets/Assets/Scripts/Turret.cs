using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameBooster;

public class Turret : MonoBehaviour
{
    public float range = 5f;
    public string targetTag;
    public Transform partToRotate;
    public float turretSpeed = 5f;
    public GameObjectUnityEvent actions;
    public float rateOfActions = 1f;
    public bool isFixed = false;

    private Transform target;
    private GameObject goTarget;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("MyActions", 0f, rateOfActions);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        faceTarget();
    }

    public void faceTarget()
    {
        if (isFixed)
        {
            return;
        }

        Vector2 direction = new Vector2(0, 0);

        if (target != null)
        {
            direction = new Vector2(
                target.position.x - transform.position.x,
                target.position.y - transform.position.y
            );
        }

        transform.up = Vector2.Lerp(transform.up, direction, Time.deltaTime * turretSpeed);
    }

    void UpdateTarget()
    {
        var goList = new List<GameObject>();

        var tagsArray = targetTag.Trim().Split(';');
        foreach (var tag in tagsArray)
        {
            goList.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }

        if (goTarget != null && goList.Contains(goTarget))
        {
            return;
        }

        GameObject[] enemies = goList.ToArray();
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToTarget = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = enemy;
            }
        }

        if (nearestTarget != null && shortestDistance <= range)
        {
            target = nearestTarget.transform;
            goTarget = nearestTarget;
        } else
        {
            target = null;
            goTarget = null;
        }
    } 

    void MyActions()
    {
        if (target != null)
        {
            actions.Invoke(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
