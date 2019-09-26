using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameBooster;

public class MyCreator : Creator
{
    void OnEnable()
    {
        if (autoCreate)
        {
            InvokeRepeating("Create", startTime, repeatTime);
        }
    }

    void OnDisable()
    {
        CancelInvoke("Create");
    }
}
