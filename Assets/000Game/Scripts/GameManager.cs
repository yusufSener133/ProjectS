using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }
    private void Awake()
    {
        if (Instance == null)
            _instance = this;
    }
    #endregion

    [SerializeField] PlayerController _player;
    [SerializeField] UIManager _UIManager;
    public PlayerController Player { get => _player; }
    public UIManager UIManager { get => _UIManager; }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}/**/
