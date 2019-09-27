using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUShieldBehavior : MonoBehaviour
{
    public GameObject shieldHolder;
    public string shieldTag;
    private Energy energy;
    public Vector3 shieldPosition;

    // Start is called before the first frame update
    void Start()
    {
        energy = shieldHolder.GetComponent<Energy>();
        shieldPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (energy.IsActive())
        {
            transform.position = shieldHolder.transform.position;
        } else if((transform.position - shieldPosition) != Vector3.zero)
        {
            transform.position = shieldPosition;
        }

        if (energy.GetEnergy() == energy.maxEnergy)
        {
            energy.StartDecrease();
        }
    }
}
