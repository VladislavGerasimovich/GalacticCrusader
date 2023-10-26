using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyTypeOneTemplate;
    [SerializeField] GameObject _enemyTypeTwoTemplate;
    [SerializeField] GameObject _enemyTypeThreeTemplate;
    [SerializeField] GameObject _enemyTypeFourTemplate;
    [SerializeField] GameObject _enemyTypeFiveTemplate;
    [SerializeField] Transform _enemyContainer;
    [SerializeField] Transform[] _spawnerPoints;

    private const string CommandEnemyTypeOne = "EnemyTypeOne";
    private const string CommandEnemyTypeTwo = "EnemyTypeTwo";
    private const string CommandEnemyTypeThree = "EnemyTypeThree";
    private const string CommandEnemyTypeFour = "EnemyTypeFour";
    private const string CommandEnemyTypeFive = "EnemyTypeFive";
    private int _currentWaveNumber;
    private List<string> _currentWave;
    private int _currentEnemy;
    private List<string> _waveOne = new List<string>() { "EnemyTypeThree", "EnemyTypeOne", "EnemyTypeTwo", "EnemyTypeThree", "EnemyTypeFour" };
    private List<string> _waveTwo = new List<string>() { "EnemyTypeTwo", "EnemyTypeThree", "EnemyTypeOne", "EnemyTypeFive" };
    private List<List<string>> _waves;

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void WorkWithWawe(int index)
    {
        switch(_currentWave[index])
        {
            case CommandEnemyTypeOne:
                CreateEnemy(_enemyTypeOneTemplate, _currentWave[index]);
                break;
            case CommandEnemyTypeTwo:
                CreateEnemy(_enemyTypeTwoTemplate, _currentWave[index]);
                break;
            case CommandEnemyTypeThree:
                CreateEnemy(_enemyTypeThreeTemplate, _currentWave[index]);
                break;
            case CommandEnemyTypeFour:
                CreateEnemy(_enemyTypeFourTemplate, _currentWave[index]);
                break;
            case CommandEnemyTypeFive:
                CreateEnemy(_enemyTypeFiveTemplate, _currentWave[index]);
                break;
        }
    }

    private void CreateEnemy(GameObject enemy, string text)
    {
        foreach (var point in _spawnerPoints)
        {
            if (point.tag == text)
            {
                Instantiate(enemy, point.position, Quaternion.identity, _enemyContainer);
            }
        }
    }

    private void Start()
    {
        _waves = new List<List<string>>() { _waveOne , _waveTwo };
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if(_currentWave == null)
        {
            return;
        }

        if(_enemyContainer.transform.childCount == 0 && _currentEnemy == 0)
        {
            WorkWithWawe(_currentEnemy);
            _currentEnemy++;
        }
        else if (_enemyContainer.transform.childCount == 0 && _currentEnemy > 0)
        {
            if (_currentEnemy < _currentWave.Count)
            {
                WorkWithWawe(_currentEnemy);
                _currentEnemy++;
            }
            else
            {
                _currentWaveNumber++;
                _currentEnemy = 0;

                if (_currentWaveNumber < _waves.Count)
                {
                    SetWave(_currentWaveNumber);
                }
                else
                {
                    _currentWave = null;
                }
            }
        }
    }
}
