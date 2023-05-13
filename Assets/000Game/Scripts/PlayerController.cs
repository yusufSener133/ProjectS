using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Player
{
    Vector2 _mousePos;

    bool isClicked = false;
    void Update()
    {
        Touching();
    }
    void Touching()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isClicked = true;
        }
        RaycastHit2D hit = Physics2D.Raycast(_mousePos, Vector2.zero);
        if (hit.collider != null && isClicked)
        {
            isClicked = false;
            if (hit.collider.CompareTag("Saloon"))
                GameManager.Instance.UIManager.EnterTavern(hit.collider.gameObject);
            if (hit.collider.CompareTag("Enemy"))
                GameManager.Instance.UIManager.EditEnemyText(hit.collider.transform);
            if (hit.collider.CompareTag("Master"))
                GameManager.Instance.UIManager.Master();
        }
    }

    public void EditValue(int value, PowerEnum who)
    {
        switch (who)
        {
            case PowerEnum.Pride:
                Pride += value;
                break;
            case PowerEnum.Greed:
                Greed += value;
                break;
            case PowerEnum.Lust:
                Lust += value;
                break;
            case PowerEnum.Envy:
                Envy += value;
                break;
            case PowerEnum.Gluttony:
                Gluttony += value;
                break;
            case PowerEnum.Wrath:
                Wrath += value;
                break;
            case PowerEnum.Sloth:
                Sloth += value;
                break;
            default:
                break;
        }
    }
}/**/
