using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletHomingTime;
    [SerializeField] private float _bulletLifeTime;

    private Rigidbody2D _rigidbody;
    private GameObject _target;
    private float _time = 0;
    private Vector2 _lastVector;

    private const string PLAYER_NAME = "Samael";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _target = GameObject.Find(PLAYER_NAME);

    }

    private void Update()
    {
      
        _time+= Time.deltaTime; 
        GoToTarget();

    }

    private void GoToTarget()
    {
        if (_time < _bulletHomingTime)
        {
            _rigidbody.velocity = new Vector2(_target.transform.position.x - transform.position.x, _target.transform.position.y - transform.position.y).normalized * _bulletSpeed;
            _lastVector = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y);
        }
        else _rigidbody.velocity = _lastVector;
        if (_time > _bulletLifeTime)
        {
            Destroy(gameObject);
        }


    }
}
