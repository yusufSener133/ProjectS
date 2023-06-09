using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryController : MonoBehaviour
{
    [Header("Assignments")]
    [SerializeField] TMP_Text _storyLineText;

    [Header("Variables")]
    [SerializeField] List<string> _storyLines;
    [SerializeField, Range(0, 1)] float _textSpeed = 0.01f;
    int _storyCount = 0;

    private void Start()
    {
        StartCoroutine(TextAnim(_storyLines[_storyCount], _storyLineText));
    }
    public void Next()
    {
        _storyCount++;
        if (_storyCount >= _storyLines.Count)
        {
            /**/
            return;
        }
        _storyLineText.text = "";
        StartCoroutine(TextAnim(_storyLines[_storyCount], _storyLineText));
    }
    IEnumerator TextAnim(string line, TMP_Text _text)
    {
        _text.GetComponent<Button>().enabled = false;
        foreach (var item in line)
        {
            _text.text += item.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
        _text.GetComponent<Button>().enabled = true;

    }
}/**/
