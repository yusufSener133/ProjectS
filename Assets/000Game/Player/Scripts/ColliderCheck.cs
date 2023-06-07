using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    private bool _win;

    public bool Win
    {
        get { return _win; }
        set { _win = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            PlayerStats.Instance.Coin++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Win"))
        {
            Win = true;
        }
    }
}
