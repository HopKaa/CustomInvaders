using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 10; //  оличество очков за уничтожение врага

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // ”ничтожаем врага и добавл€ем очки игроку
            Destroy(gameObject);
            GameManager.AddScore(scoreValue);
        }
    }
}
