using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onFirstDamage;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onDie;

    private int _initialHealth;

    private void Start()
    {
        SetInitialHealth();
    }

    public void ModifyHealth(int damageDelta)
    {
       
        _health += damageDelta;

        if (_health == _initialHealth + damageDelta)
            Debug.Log("first Damage");
            _onFirstDamage?.Invoke();

        if (_health <= 0)
            _onDie?.Invoke();

        if (damageDelta < 0)
            _onDamage?.Invoke();
    }
    private void SetInitialHealth()
    {
        _initialHealth = _health;
    }
}
