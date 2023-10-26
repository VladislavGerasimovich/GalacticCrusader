using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeThreeState : State
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _aim;

    private float _fireRate = 0.2f;
    private float _nextFire = 0.0f;
    private Vector2 _shotDirection;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, 0);

        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        _shotDirection = (_aim.transform.position - _shootPoint.position).normalized;
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        _bullet.GetComponent<EnemyTypeTwoBullet>()._shotDirection = _shotDirection;
    }
}
