using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartSettings : MonoBehaviour
{
    [SerializeField] List<string> _startStory;
    [SerializeField] TMP_Text _startStoryLineText;

    [SerializeField, Range(0, 1)] float _textSpeed = 0.1f;
    int _startStoryCount = 0;

    private void Start()
    {
        StartCoroutine(TextAnim(_startStory[_startStoryCount], _startStoryLineText));
    }
    public void Next()
    {
        _startStoryCount++;
        if (_startStoryCount >= _startStory.Count)
        {
            GameManager.Instance.NextScene();
            return;
        }
        StartCoroutine(TextAnim(_startStory[_startStoryCount], _startStoryLineText));
    }
    IEnumerator TextAnim(string line, TMP_Text _text)
    {
        _text.text = "";
        foreach (var item in line)
        {
            _text.text += item.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}
