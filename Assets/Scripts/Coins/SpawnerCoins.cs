using System;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform[] _spawnPoints;


    private int _maxCountCoins = 2;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int countSort = UnityEngine.Random.Range(0, _spawnPoints.Length);
        
        for (int i = countSort; countSort > 0; countSort--)
        {
                Array.Reverse(_spawnPoints);
        }

        for(int i= 0; i < _maxCountCoins; i++)
        {
            Instantiate(_prefab, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
