using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private GameObject _player;
    private int _lives = 3;
    private string _gameOver = "Game Over";
    private bool _canEnemies;

    public bool CanEnemies
    {
        get { return _canEnemies; }
        set { _canEnemies = value; }
    }

    private void Start()
    {
        _resetButton.onClick.AddListener(SpawnPlayers);
    }

    private void OnDestroy()
    {
        _resetButton.onClick.RemoveListener(SpawnPlayers);
    }

    private void Update()
    {
        CheckCompletion();
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < _livesUI.Length; i++)
        {
            if (i < _lives)
            {
                _livesUI[i].enabled = true;
            }
            else
            {
                _livesUI[i].enabled = false;
            }
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
        Time.timeScale = 0;
    }

    private void ResetLives()
    {
        _lives = 3;
        UpdateLivesUI();
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
        if (_player && !_spawner.IsAlive() && !_canEnemies)
        {
            _levelManager.LevelCompleted();
        }
    }

    private void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}