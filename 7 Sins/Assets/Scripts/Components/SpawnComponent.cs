using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPosition;
    public void Spawn()
    {
        Instantiate(_spawnObject, _spawnPosition.position, Quaternion.identity);
    }
}
