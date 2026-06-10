using System;
using UnityEngine;

public class SpawnerAid : BaseSpawner
{
    private int _maxCount = 1;

    private void OnEnable()
    {
        _collector.TakeAid += DestroyObject;
    }

    private void OnDisable()
    {
        _collector.TakeAid -= DestroyObject;
    }

    protected override void Spawn()
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

    private void DestroyObject(Aid aid)
    {
        Destroy(aid.gameObject);
    }
}
