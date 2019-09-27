using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    HealthPoints playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>();
        healthBar.maxValue = playerHealth.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.hp;
    }
}
