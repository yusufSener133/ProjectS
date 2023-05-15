using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameController : MonoBehaviour
{
    [Header("Assignment")]
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] List<GameObject> _missions = new List<GameObject>();
    [Header("Assignment/UI")]
    [SerializeField] GameObject _missionCompletePanel;
    [SerializeField] TMP_Text _missionCompleteText;
    [SerializeField] TMP_Text _levelText;
    [Header("Variables")]
    [SerializeField, Range(0, 1)] float _textSpeed = 0.1f;
    bool _textEnd = false;

    private void Update()
    {
        if (_playerMovement.win)
        {
            if (_playerMovement.Greed != 0)
            {
                StartCoroutine(MissionControl("Güzel ilk görevi tamamladýn. Yeni görev o zaman          "));
                _playerMovement.Greed = 0;
            }
            if (_playerMovement.Sloth != 0)
            {
                StartCoroutine(MissionControl("Güzel ikinci görevde tamam. "));
                _playerMovement.Sloth = 0;
            }
            _playerMovement.win = false;
        }
    }
    IEnumerator TextAnim(string line)
    {
        _textEnd = false;
        _missionCompleteText.text = "";
        foreach (var item in line)
        {
            _missionCompleteText.text += item.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
        _textEnd = true;
    }
    IEnumerator MissionControl(string line)
    {
        _missionCompletePanel.SetActive(true);
        StartCoroutine(TextAnim(line));
        yield return new WaitUntil(() => _textEnd);
        _missionCompletePanel.SetActive(false);
        NextMission(0, 1);
    }
    void NextMission(int x, int y)
    {
        _missions[x].SetActive(false);
        _missions[y].SetActive(true);
        _levelText.text = "Görev " + (y + 1);
    }
}/**/
