using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _startSpawnPoint;
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minSpawnPositionX;
    [SerializeField] private float _maxSpawnPositionX;
    [SerializeField] private float _maxSpawnPositionY;

    private float _elapsedTime;
    private Vector3 _lastSpawnedPosition;

    private void Start()
    {
        Initialize(_template);
        _elapsedTime = _secondsBetweenSpawn;
        _lastSpawnedPosition = _startSpawnPoint.position;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject tile))
            {
                _elapsedTime = 0;

                float spawnPositionX = Random.Range(_minSpawnPositionX, _maxSpawnPositionX);
                float spawnPositionY = Random.Range(_lastSpawnedPosition.y + _maxSpawnPositionY / 2, _lastSpawnedPosition.y + _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(spawnPositionX, spawnPositionY, transform.position.z);

                tile.SetActive(true);
                tile.transform.position = spawnPoint;
                _lastSpawnedPosition = spawnPoint;
            }
        }

        DisableObjectAbroadScreen();
    }

    public void ResetSpawner()
    {
        ResetPool();
        _lastSpawnedPosition = _startSpawnPoint.position;
    }
}
