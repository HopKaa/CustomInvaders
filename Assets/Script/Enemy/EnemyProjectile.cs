using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private const float Speed = 100f;

    private void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boundary>())
        {
            Destroy(gameObject);
        }
    }
}