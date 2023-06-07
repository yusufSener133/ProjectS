using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameController : MonoBehaviour
{
    [Header("Assignment")]
    [SerializeField] ColliderCheck _player;
    [SerializeField] List<GameObject> _missions = new List<GameObject>();
    [SerializeField] Transform _startPos;
    [Header("Assignment/UI")]
    [SerializeField] GameObject _healthCanvas;
    [SerializeField] GameObject _talkPanel;
    [SerializeField] GameObject _endPanel;
    [SerializeField] Animator _falling;
    [SerializeField] Button _storyLineButton;
    [SerializeField] TMP_Text _storyLineText;
    [SerializeField] TMP_Text _levelText;
    [Header("Variables")]
    [SerializeField] List<string> _storyLines;
    [SerializeField, Range(0, 1)] float _textSpeed = 0.1f;
    int _missionCount = 0;

    private void Start()
    {
        TextUpdate();
        _falling.Play("Start");
    }
    private void Update()
    {
        if (_player.Win)
        {
            EndMission();
            _player.gameObject.SetActive(false);
            _player.transform.position = _startPos.position;
            _player.Win = false;
        }
    }
    private void TextUpdate()
    {
        _talkPanel.SetActive(true);
        StartCoroutine(TextAnim(_storyLines[_missionCount]));
    }
    private IEnumerator TextAnim(string line)
    {
        _storyLineButton.interactable = false;
        _storyLineText.text = "";
        foreach (var item in line)
        {
            _storyLineText.text += item.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
        _storyLineButton.interactable = true;
    }
    public void NextMissionButton()
    {
        if (_storyLines.Count == _missionCount + 1)
        {
            EndGame();
            return;
        }
        _player.gameObject.SetActive(true);
        _talkPanel.SetActive(false);
        NextMission(_missionCount);
    }
    private void EndMission()
    {
        _talkPanel.SetActive(true);
        StartCoroutine(TextAnim(_storyLines[_missionCount]));
    }
    private void NextMission(int x)
    {
        _missions[x].SetActive(false);
        _missions[x + 1].SetActive(true);
        if (x + 1 > 4)
        {
            _healthCanvas.transform.SetParent(_missions[x + 1].transform);
        }
        _levelText.text = "Görev " + (x + 1);
        _missionCount++;
    }

    private void EndGame()
    {
        _endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}/**/
