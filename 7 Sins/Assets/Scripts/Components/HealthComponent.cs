using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onDie;

    public void ModifyHealth(int damageDelta)
    {
        _health += damageDelta;
        if (_health <= 0)
            _onDie?.Invoke();
        if (damageDelta < 0)
            _onDamage?.Invoke();
        
    }
}
