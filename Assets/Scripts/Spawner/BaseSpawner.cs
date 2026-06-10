using System;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected Transform[] _pointsSpawn;
    [SerializeField] protected Collector _collector;

    protected int _zeroValue = 0;


    private void Awake()
    {
        Shuffle();
    }

    private void Start()
    {
        Spawn();
    }

    protected abstract void Spawn();

    private void Shuffle()
    {
        Transform temp;

        for (int i = _pointsSpawn.Length - 1; i > _zeroValue; i--)
        {
            int randomNumber = UnityEngine.Random.Range(_zeroValue, _pointsSpawn.Length-1);

            temp = _pointsSpawn[randomNumber];
            _pointsSpawn[randomNumber] = _pointsSpawn[i];
            _pointsSpawn[i] = temp;
        }
    }
}
