using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _moveSpeed = 500f;
    private PointManager _pointManager;

    private void Start()
    {
        _pointManager = PointManager.Instance;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipEnemyMovement>())
        {
            Destroy(collision.gameObject);
            _pointManager.UpdateScore(50);
            Destroy(gameObject);
        }

        if (collision.GetComponent<Boundary>())
        {
            Destroy(gameObject);
        }
    }
}
