using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace FirstScene
{
    public class UIManager : MonoBehaviour
    {
        [Header("Assignments")]
        [SerializeField] List<string> _story;
        [SerializeField] TMP_Text _storyLineText;
        [SerializeField] TMP_Text _startStoryLineText;
        [SerializeField] Image _startImage;
        [SerializeField] Button _nextButton;

        [Header("Variables")]
        [SerializeField, Range(0, 1)] float _textSpeed = 0.1f;
        int _storyCount = 0;
        private void Start()
        {
            
        }
        public void NextButton()
        {
            _storyCount++;
            StartCoroutine(TextAnim(_story[_storyCount], _storyLineText));
        }

        IEnumerator TextAnim(string line, TMP_Text _text)
        {
            _nextButton.interactable = false;
            _text.text = "";
            foreach (var item in line)
            {
                _text.text += item.ToString();
                yield return new WaitForSeconds(_textSpeed);
            }
            _nextButton.interactable = true;
        }

    }/**/
}
