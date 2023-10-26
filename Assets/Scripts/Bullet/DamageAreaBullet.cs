using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAreaBullet : Bullet
{
    [SerializeField] private float _lifeTime = 1;
    [SerializeField] private int _damage = 5;

    void Update()
    {
        _lifeTime -= Time.deltaTime;
        
        if(_lifeTime <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Border border))
        {
            Die();
        }
        else if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            _damage = 0;
        }
    }
}
