using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private EnemiesCounter _enemies;
    private GameOverPanel _gameOverPanel;
    private Player _player;

    private void Awake()
    {
        _enemies = FindObjectOfType<EnemiesCounter>();
        _player = FindObjectOfType<Player>();
        _gameOverPanel = FindObjectOfType<GameOverPanel>();
    }

    private void OnEnable()
    {
        _enemies.EnemiesEnded += OnEnemiesEnded;
    }

    private void OnDisable()
    {
        _enemies.EnemiesEnded -= OnEnemiesEnded;
    }

    private void OnEnemiesEnded()
    {
        _gameOverPanel.ShowPanel();
        _player.Stop();
    }
}
