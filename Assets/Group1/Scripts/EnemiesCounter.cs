using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesCounter : MonoBehaviour
{
    private Enemy[] _enemies;
    private float _currentCount;

    public event UnityAction EnemiesEnded;

    private void Awake()
    {
        _enemies = GetComponentsInChildren<Enemy>();
        _currentCount = _enemies.Length;
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Killed += OnEnemyKilled;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Killed -= OnEnemyKilled;
        }
    }

    private void OnEnemyKilled()
    {
        _currentCount--;
        if (_currentCount == 0)
        {
            EnemiesEnded?.Invoke();
        }
    }
}
