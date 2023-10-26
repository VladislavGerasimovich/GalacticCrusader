using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private float _timeToChangeDirection;
    private float _fireRate = 2f;
    private float _nextFire = 0.0f;

    private void FixedUpdate()
    {
        _timeToChangeDirection += Time.deltaTime;
        transform.Translate(0, _speed, 0);

        if (_timeToChangeDirection >= _delay)
        {
            _speed = -_speed;
            _timeToChangeDirection = 0;
        }
    }
}
