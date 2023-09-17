using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMobAI : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootingPosition;

    [SerializeField] private float _attackCooldown;

    private Animator _animator;
    private bool _isHeroInVision;
    private IEnumerator _currentCoroutine;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void EnterState(IEnumerator coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = coroutine;
        StartCoroutine(_currentCoroutine);
        
    }
    //Вызывается из EnterTrigger
    public void OnHeroInVision()
    {
        _isHeroInVision = true;
        EnterState(Attack());
    }
    //Вызывается из ExitTrigger
    private void LoseHero()
    {
        _isHeroInVision = false;
    }

    private IEnumerator Attack()
    {
       if (_isHeroInVision)
            EnterState(Shoot());
        
        yield return null;
    }
    private IEnumerator Shoot()
    {
        while (_isHeroInVision)
        {
            Instantiate(_projectile, _shootingPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(_attackCooldown);

        }

    }
}
