using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public bool isActive;
    public float inicialEnergy, maxEnergy, decreaseVelocity;
    float energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = inicialEnergy;
    }

    public void ChangeEnergy(float value)
    {
        energy += value;
    }

    public float GetEnergy()
    {
        return energy;
    }

    public void StartDecrease()
    {
        isActive = true;
        InvokeRepeating("Decrease", 0f, 1f);
    }

    private void Decrease()
    {
        energy -= decreaseVelocity;
        if (inicialEnergy >= energy)
        {
            energy = inicialEnergy;
            CancelInvoke("Decrease");
            isActive = false;
        }
    }

    public void SetIsActive(bool status)
    {
        isActive = status;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
