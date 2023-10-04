using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _floatingSpeed;
    [SerializeField] private float _dashingSpeed;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashingCooldown;


    [Header("Shooting Settings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootingPosition;
    [SerializeField] private float _shootingDelay;




    [NonSerialized] public bool isJumpButtonPressed;
    [NonSerialized] public bool isShootingButtonPressed;
    [NonSerialized] public bool isDashing;
    [NonSerialized] public bool canDash = true;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private GroundCheck _groundCheck;
    private PolygonCollider2D _polygonCollider;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }
   
    private void FixedUpdate()
    {
        HorizontalMovement();
       FloatMidAir();
    }
    private void HorizontalMovement()
    {
        if (!isDashing)
        {
            var xVelocity = _direction.x;
            _rigidbody.velocity = new Vector2(xVelocity * _movementSpeed, _rigidbody.velocity.y);
        }
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    public void Jump()
    {
        if (!_groundCheck.IsGrounded()) return;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }
    public void FloatMidAir()
    {
        if (isJumpButtonPressed && !_groundCheck.IsGrounded() && _rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity = new Vector2(_direction.x, _direction.y );
        }
    }

    public IEnumerator Shoot()
    {
        while (isShootingButtonPressed)
        {
            var bullet = Instantiate(_bulletPrefab, _shootingPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(_shootingDelay);
        }
    }

    public IEnumerator Dash()
    {
        if (canDash)
        {
            isDashing = true;

            var dashingVector = new Vector2(_direction.x, 0);
            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = Vector2.zero;

            _rigidbody.AddForce(dashingVector * _jumpSpeed, ForceMode2D.Impulse);
            _polygonCollider.enabled = false; 
        }
        canDash = false;
        yield return new WaitForSeconds(_dashingTime);

        _polygonCollider.enabled = true;
        _rigidbody.gravityScale = 1;
        isDashing = false;

        yield return new WaitForSeconds(_dashingCooldown);
        canDash = true;
    }
}
