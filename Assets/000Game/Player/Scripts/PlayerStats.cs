using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] GameObject _player;
    [SerializeField] Image _playerHealthBar;
    [SerializeField] TMP_Text _playerHealthBarText;
    [SerializeField] TMP_Text _coinText;
    [SerializeField] GameObject _deathPanel;

    [SerializeField] float _health;
    [SerializeField] float _maxHealth;
    float _coin = 0;
    public float Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            if (_coin % 5 == 0)
            {
                SetHealthUI();
                if (_health != _maxHealth && _health >= _maxHealth)
                {
                    _health += 10;
                    _coin -= 5;
                }
            }
            _coin = value;
            _coinText.text = "Coin : " + (int)_coin;
        }
    }
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        else
            Instance = this;
    }
    private void Start()
    {
        _health = _maxHealth;
        SetHealthUI();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        SetHealthUI();
        CheckDeath();
    }
    private void SetHealthUI()
    {
        _playerHealthBar.fillAmount = _health / _maxHealth;
        _playerHealthBarText.text = (int)_health + "/" + (int)_maxHealth;
    }
    private void CheckDeath()
    {
        if (_health <= 0)
        {
            _health = 0;
            _player.SetActive(false);
            StartCoroutine(Restarting());
        }
    }
    private IEnumerator Restarting()
    {
        _deathPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
