using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyBar : MonoBehaviour
{
    public Slider energyBar;
    public string element;

    Energy elementEnergy;
    // Start is called before the first frame update
    void Start()
    {
        elementEnergy = GameObject.FindGameObjectWithTag(element).GetComponent<Energy>();
        energyBar.maxValue = elementEnergy.maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = elementEnergy.GetEnergy();
    }
}
