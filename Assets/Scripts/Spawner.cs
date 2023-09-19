using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _afterSpawnTime;
    private int _spawnedEnemiesCount;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _afterSpawnTime += Time.deltaTime;

        if (_afterSpawnTime >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedEnemiesCount++;
            EnemyCountChanged?.Invoke(_spawnedEnemiesCount, _currentWave.Count);
            _afterSpawnTime = 0;
        }

        if (_spawnedEnemiesCount == _currentWave.Count)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void SetNextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawnedEnemiesCount = 0;
        EnemyCountChanged?.Invoke(_spawnedEnemiesCount, _currentWave.Count);
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public int Delay;
    public int Count;
}
