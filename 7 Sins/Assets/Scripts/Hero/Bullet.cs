using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _bulletVelocity;
    [SerializeField] private float _bulletLifeTime;

    private Rigidbody2D _rigidbody;
    private Vector3 _mousePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var bulletVector = new Vector2(_mousePosition.x - transform.position.x, _mousePosition.y - transform.position.y);
       
        _rigidbody.velocity = bulletVector.normalized * _bulletVelocity;
        var rotation = new Vector2(transform.position.x - _mousePosition.x, transform.position.y - _mousePosition.y);
        float instanceRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, instanceRotation + 90);
        StartCoroutine(DestroyAfterSeconds());
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(_bulletLifeTime);
        Destroy(gameObject);
    }
}
