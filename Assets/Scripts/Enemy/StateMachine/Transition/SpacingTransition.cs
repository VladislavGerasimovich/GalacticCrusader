using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpacingTransition : Transition
{
    [SerializeField] private MoveState _moveState;

    private float _time = 8;


    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            NeedTransit = true;
            _time = 4;
        }
    }
}
