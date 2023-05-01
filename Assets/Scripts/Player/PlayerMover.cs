using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _currentSpeed;
    private float _baseSpeed = 3f;
    private bool _isMoving = false;
    
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        Move();
        Animation();
    }

    public void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_direction.x * _currentSpeed, _rigidbody.velocity.y);

        FLip();
        _isMoving = true;
    }

    private void Animation()
    {
        //if (_direction.po)
        //{
        //    _animator.SetFloat("Horizontal",1);
        //}
        //else
        //{
        //    _animator.SetFloat("Horizontal", 0);
        //}
    }

    private void FLip()
    {
        if (_direction.x<0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX=false;
        }
    }
}
