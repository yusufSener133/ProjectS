using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject _spellPrefab;
    [SerializeField] Transform _player;
    [SerializeField] float _minDamage;
    [SerializeField] float _maxDamage;
    [SerializeField] float _spellForce;
    [SerializeField] float _cooldown;

    private void Start()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(_cooldown,_cooldown+3));
        if (_player != null)
        {
            GameObject spell = Instantiate(_spellPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (_player.position - transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * _spellForce;
            spell.GetComponent<TestEnemyProjectile>().Damage = Random.Range(_minDamage, _maxDamage);
            Destroy(spell, 10);
        }
        StartCoroutine(Shoot());
    }
}
