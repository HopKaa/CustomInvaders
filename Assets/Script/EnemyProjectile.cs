using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float _speed = 100f;

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
