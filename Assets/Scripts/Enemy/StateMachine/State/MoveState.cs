using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveState: State
{
    [SerializeField] private int _endPosition;
    [SerializeField] private int _minRange;
    [SerializeField] private int _maxRange;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _aim;

    private float _fireRate = 0.2f;
    private float _nextFire = 0.0f;
    private Vector2 _shotDirection;
    private int _direction = 1;
    private float _timeToAttack = 5;

    private void OnEnable()
    {
        SetEndPosition();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _endPosition, transform.position.z), _speed * Time.deltaTime);
        
        if(transform.position.y == _endPosition)
        {
            _timeToAttack -= Time.deltaTime;

            if (_timeToAttack > 0)
            {
                if (Time.time > _nextFire)
                {
                    _nextFire = Time.time + _fireRate;
                    Shoot();
                }
            }
            else
            {
                SetEndPosition();
                _timeToAttack = 5;
            }
        }
    }

    private void SetEndPosition()
    {
        _endPosition = UnityEngine.Random.Range(_minRange, _maxRange) * _direction;

        if (_endPosition > 0)
        {
            _direction = -_direction;
        }
        else if (_endPosition < 0)
        {
            _direction = -_direction;
        }
    }

    public void Shoot()
    {
        _shotDirection = (_aim.transform.position - _shootPoint.position).normalized;
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        _bullet.GetComponent<EnemyTypeTwoBullet>()._shotDirection = _shotDirection;
    }
}
