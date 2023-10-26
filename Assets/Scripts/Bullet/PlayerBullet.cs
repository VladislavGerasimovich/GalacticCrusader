using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Border border))
        {
            Die();
        }
        else if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            Die();
        }
    }
}
