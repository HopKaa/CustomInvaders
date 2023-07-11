using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 10; // ���������� ����� �� ����������� �����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // ���������� ����� � ��������� ���� ������
            Destroy(gameObject);
            GameManager.AddScore(scoreValue);
        }
    }
}
