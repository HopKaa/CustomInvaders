using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    private int _lives = 3;
    [SerializeField] private Image[] _livesUI;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Button _resetButton;
    [SerializeField] private GameObject _playersPrefab;
    [SerializeField] private Transform _canvasParent;

    private GameObject _players;

    private void Start()
    {
        _resetButton.onClick.AddListener(SpawnPlayers);
        _resetButton.onClick.AddListener(ResetLives);
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
        _lives -= 1;
        UpdateLivesUI();

        if (_lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Destroy(_players);
        _gameOverText.text = "Game Over";
        Time.timeScale = 0;
    }

    private void ResetLives()
    {
        _lives = 3;
        UpdateLivesUI();
    }

    private void SpawnPlayers()
    {
        if (_players == null)
        {
            _players = Instantiate(_playersPrefab, _canvasParent);
        }
    }

    public void CheckCompletion()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            _gameOverText.text = "Complete";
            Time.timeScale = 0;
        }
    }
}