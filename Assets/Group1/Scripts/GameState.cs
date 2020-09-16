using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private EnemiesCounter _enemies;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private Player _player;

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
