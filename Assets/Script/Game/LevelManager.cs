using TMPro;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private int _currentLevelIndex = 0;
    private string _gameComplete = "Complete";

    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private TMP_Text _gameText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private TMP_Text _goText;
    [SerializeField] private Level[] _levels;
    [SerializeField] private PlayerLives _playerLives;
    [SerializeField] private PauseMenu _pauseMenu;

    public void StartLevel()
    {
        StartCoroutine(LevelRoutine());
    }

    private IEnumerator LevelRoutine()
    {
        _levelText.text = "Level " + (_currentLevelIndex + 1);
        yield return new WaitForSeconds(1f);
        _countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        _countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        _countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        _countdownText.text = string.Empty;
        _goText.text = "GO!";
        yield return new WaitForSeconds(1f);
        _goText.text = string.Empty;
        _pauseMenu.ResumeGame();
        if (enemySpawner != null && projectileSpawner != null)
        {
            enemySpawner.CreateEnemyFormation();
            SetEnemySpeed(_levels[_currentLevelIndex].EnemySpeed);
            SetShootInterval(_levels[_currentLevelIndex].ShootInterval);
        }
        _playerLives.LevelLaunce();
    }


    private void SetEnemySpeed(float speed)
    {
        enemySpawner.SetEnemySpeed(speed);
    }

    private void SetShootInterval(float interval)
    {
        projectileSpawner.SetSpawnInterval(interval);
    }

    private void EndGame()
    {
        _pauseMenu.PauseGame();
        _gameText.text = _gameComplete;
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
            StartCoroutine(StartNextLevel());
        }
    }

    private IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(1f);
        _playerLives.StartNextLevel();
    }
}