using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    private float _fireRate = 0.3f;
    private float _nextFire = 0.0f;

    public void Update()
    {
        if(Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
