using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    private float _timeToChangeDirection;
    private float _fireRate = 2f;
    private float _nextFire = 0.0f;

    private void FixedUpdate()
    {
        _timeToChangeDirection += Time.deltaTime;
        transform.Translate(_speed, 0, 0);

        if(_timeToChangeDirection >= _delay)
        {
            _speed = -_speed;
            _timeToChangeDirection = 0;
        }

        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
    }
}
