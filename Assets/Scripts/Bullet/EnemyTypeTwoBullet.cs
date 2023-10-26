using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeTwoBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public Vector2 _shotDirection;

    void FixedUpdate()
    {
        transform.Translate(_shotDirection * _speed * Time.deltaTime, Space.World);
    }

    public void Die()
    {
        Destroy(gameObject);
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
            Die();
        }
    }
}
