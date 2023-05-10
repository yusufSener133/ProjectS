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
        [SerializeField] List<string> _startStory;
        [SerializeField] List<string> _story;
        [SerializeField] List<Sprite> _textures;
        [SerializeField] TMP_Text _storyLineText;
        [SerializeField] TMP_Text _startStoryLineText;
        [SerializeField] Image _startImage;
        [SerializeField] Button _nextButton;

        [Header("Variables")]
        [SerializeField, Range(0, 1)] float _textSpeed = 0.1f;
        int _storyCount = 0;
        private void Start()
        {
            StartStory();
        }
        void StartStory()
        {
            int i = 0;
            StartCoroutine(TextAnim(_startStory[i]));
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
