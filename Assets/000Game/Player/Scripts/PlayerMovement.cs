using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator _animator;

    [SerializeField] float _speed = 3f;
    Vector2 _direction;
    float _hor, _ver;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        TakeInput();
        Move();
    }
    void TakeInput()
    {
        _direction = Vector2.zero;
        _hor = Input.GetAxis("Horizontal");
        _ver = Input.GetAxis("Vertical");
        if (_hor > 0)
            _direction = Vector2.right;
        else if (_hor < 0)
            _direction = Vector2.left;
        if (_ver > 0)
            _direction = Vector2.up;
        else if (_ver < 0)
            _direction = Vector2.down;

    }
    void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        if (_direction.x != 0 || _direction.y != 0)
            SetAnimation(_direction);
        else
            _animator.SetLayerWeight(1, 0);
    }
    void SetAnimation(Vector2 direction)
    {
        _animator.SetLayerWeight(1, 1);
        _animator.SetFloat("_hor", direction.x);
        _animator.SetFloat("_ver", direction.y);
    }
}
