using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnRange;

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(transform.position.x - _spawnRange.x, transform.position.x + _spawnRange.x),
            Random.Range(transform.position.y - _spawnRange.y, transform.position.y + _spawnRange.y),
            Random.Range(transform.position.z - _spawnRange.z, transform.position.z + _spawnRange.z));
    }
}
