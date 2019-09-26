using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameBooster;

public class HealthPoints : MonoBehaviour
{
    public float hp = 1f;
    public float maxHp = 1f;
    public GameObjectUnityEvent actionsWhenDie;

    private void Start()
    {
    }

    public void removeHP(float damage)
    {
        this.hp -= damage;

        if (hp <= 0)
        {
            die();
        }
    }

    public void addHP(float restore)
    {
        if (hp < maxHp)
        {
            this.hp += restore;
        }
    }

    private void die()
    {
        actionsWhenDie.Invoke(this.gameObject);
    }
}
