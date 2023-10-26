using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeFiveBullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }
}
