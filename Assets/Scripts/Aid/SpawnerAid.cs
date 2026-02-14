using System;
using UnityEngine;

public class SpawnerAid : MonoBehaviour
{
    [SerializeField] private Aid _prefab;
    [SerializeField] private Transform[] _pointsSpawn;

    private int _maxCount = 1;

    private void Start() 
    {
        Spawn();
    }

    private void Spawn()
    {
        int countSort = UnityEngine.Random.Range(0, _pointsSpawn.Length);

        for (int i = countSort; countSort > 0; countSort--)
        {
            Array.Reverse(_pointsSpawn);
        }

        for (int i = 0; i < _maxCount; i++)
        {
            Instantiate(_prefab, _pointsSpawn[i].position, Quaternion.identity);
        }
    }
}
