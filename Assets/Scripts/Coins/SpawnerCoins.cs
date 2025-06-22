using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private Transform[] _points;

    private int _maxCountCoins = 2;

    private void Start()
    {
        _points = new Transform[_maxCountCoins];
        GetPosition();
        Spawn();
    }

    private void GetPosition()
    {
        for (int i = 0; i < _maxCountCoins; i++)
        {
            _points[i] = _spawnPoints[Random.Range(0,_spawnPoints.Length)];
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            var spawn=Random.Range(0, _points.Length+1);
            Instantiate(_prefab, _spawnPoints[spawn].position,Quaternion.identity);

        }
    }
}
