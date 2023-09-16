using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _floatingSpeed;

    public bool isJumpButtonPressed;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private GroundCheck _groundCheck;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
    }
   
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        HorizontalMovement();
        FloatMidAir();
    }
    private void HorizontalMovement()
    {
        var xVelocity = _direction.x;
        _rigidbody.velocity = new Vector2(xVelocity * _movementSpeed, _rigidbody.velocity.y);
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    public float Jump()
    {
        if (_groundCheck.IsGrounded())
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
        return _rigidbody.velocity.y;


    }
    public void FloatMidAir()
    {
        if (isJumpButtonPressed && !_groundCheck.IsGrounded() && _rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity = new Vector2(_direction.normalized.x, _direction.y* _floatingSpeed);
        }
    }
}
