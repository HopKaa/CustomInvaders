using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    private int _lives = 3;
    [SerializeField] private Image[] _livesUI;
    [SerializeField] private TMP_Text _gameOverText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            _lives -= 1;

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

            if (_lives <= 0)
            {
                Destroy(gameObject);
                _gameOverText.text = "Game Over";
                Time.timeScale = 0;
            }
        }
    }
}
