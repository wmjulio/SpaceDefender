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

    private Transform target;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("MyActions", 0f, rateOfActions);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(
                target.position.x - transform.position.x,
                target.position.y - transform.position.y
            );

            transform.up = direction;
        }
    }

    public void faceTarget(GameObject gObject)
    {
        Debug.Log(gObject.name);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
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
        } else
        {
            target = null;
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
