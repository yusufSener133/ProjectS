using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _coin;
    [SerializeField] Image _healthBar;
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
        _healthBar.fillAmount = _health / _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthBar.fillAmount = _health / _maxHealth;
        CheckDeath();
    }
    private void CheckDeath()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }
}
