using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    private float _damage;

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyController>() != null)
            {
                collision.GetComponent<EnemyController>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
