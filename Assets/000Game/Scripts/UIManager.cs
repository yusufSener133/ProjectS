using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Assignments")]
    [SerializeField] GameObject _tavern;
    [SerializeField] GameObject _talkPanel;
    [SerializeField] GameObject _masterPanel;
    [SerializeField] GameObject _endPanel;

    [Header("TalkLines")]
    [SerializeField] List<string> _enemyText = new List<string>();
    public void Master()
    {
        PanelControl(_tavern,_masterPanel);
    }
    public void EnterTavern(GameObject go)
    {
        go.SetActive(false);
        PanelControl(_talkPanel, _tavern);
    }
    public void PanelControl(GameObject goClosed, GameObject goOpen)
    {
        goClosed.SetActive(false);
        goOpen.SetActive(true);
    }
    public void EditEnemyText(Transform go) => StartCoroutine(EditEnemyTextDestroy(go));
    IEnumerator EditEnemyTextDestroy(Transform go)
    {
        go.GetComponentInChildren<TMP_Text>().text = _enemyText[Random.Range(0, _enemyText.Count)];
        yield return new WaitForSeconds(1f);
        go.GetComponentInChildren<TMP_Text>().text = "";
    }

    public void AcceptButton()
    {
        GameManager.Instance.NextScene();
    }
    public void RejectButton() => StartCoroutine(RejectButtonWait());
    public IEnumerator RejectButtonWait()
    {
        PanelControl(_masterPanel, _endPanel);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
    public void QuitGame() => Application.Quit();
}
