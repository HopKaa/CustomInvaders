using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerLives _playerLives;

    public void Init(PlayerLives model)
    {
        _playerLives = model;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyProjectile>())
        {
            Destroy(collision.gameObject);
            _playerLives.DecreaseLives();
        }

        if (collision.GetComponent<ShipEnemyMovement>())
        {
            Destroy(collision.gameObject);
            _playerLives.DecreaseLives();
        }
    }
}