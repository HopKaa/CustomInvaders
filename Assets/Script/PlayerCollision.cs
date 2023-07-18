using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerLives _playerLives;

    private void Start()
    {
        _playerLives = GetComponentInParent<PlayerLives>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            _playerLives.DecreaseLives();
        }
    }
}