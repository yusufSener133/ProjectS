using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Player"))
            {
                PlayerStats.Instance.TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
