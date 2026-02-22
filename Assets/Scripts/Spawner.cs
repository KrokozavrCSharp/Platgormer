using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _pointsSpawn;

    private int _maxCountAid = 1;
    private int _maxCountCoins = 2;
    private int _maxCount;
    private int _zeroValue = 0;

    private void Awake()
    {
        GetCount();
    }

    private void Start() 
    {
        Spawn();
    }

    private void Spawn()
    {
        int countSort = UnityEngine.Random.Range(_zeroValue, _pointsSpawn.Length);

        for (int i = countSort; countSort > _zeroValue; countSort--)
        {
            Array.Reverse(_pointsSpawn);
        }

        for (int i = 0; i < _maxCount; i++)
        {
            Instantiate(_prefab, _pointsSpawn[i].position, Quaternion.identity);
        }
    }

    private void GetCount()
    {
        if (_prefab.TryGetComponent(out Aid aid))
        {
            _maxCount = _maxCountAid;
        }
        else
            _maxCount = _maxCountCoins;
    }
}
