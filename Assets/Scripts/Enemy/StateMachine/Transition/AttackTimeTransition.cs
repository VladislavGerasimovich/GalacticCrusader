using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimeTransition : Transition
{
    private float _time = 5; 

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            NeedTransit = true;
            _time = 5;
        }
    }
}
