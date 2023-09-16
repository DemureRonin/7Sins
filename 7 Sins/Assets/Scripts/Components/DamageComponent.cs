using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private int _damageDelta;


    public void ApplyDamageDelta(GameObject gameObject)
    {
       var healthComponent =  gameObject.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.ModifyHealth(_damageDelta);
        }
    }
}
