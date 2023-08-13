using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _currentLevelIndex = 0;
    private string _gameComplete = "Complete";

    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private TMP_Text _gameText;
    [SerializeField] private Level[] _levels;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private TMP_Text _goText;

    public void StartLevel()
    {
        Level currentLevel = _levels[_currentLevelIndex];

        enemySpawner.CreateEnemyFormation();
        SetEnemySpeed(currentLevel.enemySpeed);
        SetShootInterval(currentLevel.shootInterval);
    }

    private void SetEnemySpeed(float speed)
    {
        enemySpawner.SetEnemySpeed(speed);
    }

    private void SetShootInterval(float interval)
    {
        projectileSpawner.SetSpawnInterval(interval);
    }

    public void LevelCompleted()
    {
        _currentLevelIndex++;

        if (_currentLevelIndex >= _levels.Length)
        {
            EndGame();
        }
        else
        {
            StartLevel();
        }
    }
    private void EndGame()
    {
        Time.timeScale = 0;
        _gameText.text = _gameComplete;
    }
}

