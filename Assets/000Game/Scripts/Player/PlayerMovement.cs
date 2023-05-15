using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    [HideInInspector] public bool win;
    Animator _animator;
    [SerializeField] float _speed = 3f;
    Vector3 _mousePos;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = Vector2.MoveTowards(transform.position, _mousePos, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            win = true;
        }
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Greed++;
        }
        if (collision.CompareTag("Enemy"))
        {
            _animator.Play("PlayerHitAnim");
            Sloth++;
        }
    }
}
