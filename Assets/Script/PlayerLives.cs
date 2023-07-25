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

    private GameObject _player;
    private int _lives = 3;
    private string _gameOver = "Game Over";
    private string _gameComplete = "Complete";

    private void Start()
    {
        _resetButton.onClick.AddListener(SpawnPlayers);
        _resetButton.onClick.AddListener(ResetLives);
    }

    private void OnDestroy()
    {
        _resetButton.onClick.RemoveListener(SpawnPlayers);
        _resetButton.onClick.RemoveListener(ResetLives);
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
        }
    }

    private void CheckCompletion()
    {
        if (_player && !_spawner.IsAlive())
        {
            _gameOverText.text = _gameComplete;
            Time.timeScale = 0;
        }
    }

    private void Init()
    {
        PlayerShip playerShip = GetComponent<PlayerShip>();
        if (playerShip)
        {
            playerShip.Init(this);
        }
    }
}