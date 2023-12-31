using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private Image[] _livesUI;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Button _resetButton;
    [SerializeField] private GameObject _playersPrefab;
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private PauseMenu _pauseMenu;

    private GameObject _player;
    private int _lives = 3;
    private string _gameOver = "Game Over";
    private bool _levelLaunced;

    private void Start()
    {
        _resetButton.onClick.AddListener(SpawnPlayers);
    }

    private void OnDestroy()
    {
        _resetButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        CheckCompletion();
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < _livesUI.Length; i++)
        {
            _livesUI[i].enabled = i < _lives;
        }
    }

    public void DecreaseLives()
    {
        _lives--;
        UpdateLivesUI();

        if (_lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Destroy(_player);
        _gameOverText.text = _gameOver;
        _pauseMenu.PauseGame();
    }

    private void ResetLives()
    {
        _lives = 3;
        UpdateLivesUI();
    }

    public void LevelLaunce()
    {
        _levelLaunced = true;
    }
    private void SpawnPlayers()
    {
        if (_player == null)
        {
            _player = Instantiate(_playersPrefab, _canvasParent);
            _player.GetComponent<PlayerShip>().Init(this);
            _player.GetComponent<ProjectileShoot>().Init(_canvas);
            _resetButton.onClick.RemoveAllListeners();
            _resetButton.onClick.AddListener(ResetScene);
            _levelManager.StartLevel();
        }
    }

    private void CheckCompletion()
    {
        if (_player && !_spawner.IsAlive() && _levelLaunced)
        {
            StartCoroutine(StartNextLevel());
            _levelLaunced = false;
        }    
    }

    private void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public IEnumerator StartNextLevel()
    {
        yield return null;
        _levelManager.LevelCompleted();
        _levelManager.StartLevel();
    }
}