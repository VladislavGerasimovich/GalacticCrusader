using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterState : State
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(0, _speed, 0);
    }
}
