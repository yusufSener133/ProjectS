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
        [SerializeField] Button _nextButton;

        [Header("Variables")]
        [SerializeField] bool _nextLine = false;
        [SerializeField,Range(0,1)] float _textSpeed = 0.1f;
        int _storyCount = 0;
        private void Start()
        {
            StartCoroutine(TextAnim(_story[_storyCount]));
        }

        public void NextButton()
        {
            _storyCount++;
            StartCoroutine(TextAnim(_story[_storyCount]));
        }

        IEnumerator TextAnim(string line)
        {
            _nextButton.interactable = false;
            _storyLineText.text = "";
            foreach (var item in line)
            {
                _storyLineText.text += item.ToString();
                yield return new WaitForSeconds(_textSpeed);
            }
            _nextButton.interactable = true;
        }

    }/**/
}
