using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    [SerializeField] GameObject _spellPrefabs;
    [SerializeField] float _minDamage;
    [SerializeField] float _maxDamage;
    [SerializeField] float _spellForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject spell = Instantiate(_spellPrefabs, transform.position, Quaternion.identity);
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * _spellForce;
            spell.GetComponent<TestProjectile>().Damage = Random.Range(_minDamage, _maxDamage);
            Destroy(spell, 10);
        }
    }

}
