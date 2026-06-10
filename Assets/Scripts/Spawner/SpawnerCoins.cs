using System;
using UnityEngine;

public class SpawnerCoins : BaseSpawner
{
    private int _maxCount = 2;

    private void OnEnable()
    {
        _collector.TakeCoin += DestroyObject;
    }

    private void OnDisable()
    {
        _collector.TakeCoin -= DestroyObject;
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

    private void DestroyObject(Coin coin)
    {
        Destroy(coin.gameObject);
        Debug.Log("Takecoin");
    }

    private void Shuffle()
    {

    }
}
