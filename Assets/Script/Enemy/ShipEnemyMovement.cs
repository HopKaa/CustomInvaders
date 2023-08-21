using UnityEngine;

public class ShipEnemyMovement : MonoBehaviour
{
    private float _moveSpeed = 200f;
    private InvadersMoving _moving;
    private bool _hasTriggeredBoundary = false;

    public void Init(InvadersMoving moven)
    {
        _moving = moven;
    }

    private void Start()
    {
        _moving.MovingChanged += OnMovingChaged;
    }

    private void OnDestroy()
    {
        _moving.MovingChanged -= OnMovingChaged;
    }

    private void OnMovingChaged()
    {
        if (!_hasTriggeredBoundary)
        {
            var trans = transform;
            trans.position = new Vector3(trans.position.x, trans.position.y - 50, trans.position.z);
            _moveSpeed *= -1;
            _hasTriggeredBoundary = true;
        }
    }

    private void Update()
    {
        _hasTriggeredBoundary = false;
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float speed)
    {
        _moveSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boundary>())
        {
            _moving.InvaderTouchBoundary();
        }
    }

    public void DestroyEnemy()
    {
        float distanceToPlayer = Mathf.Infinity; 
        PlayerShip playerShip = FindObjectOfType<PlayerShip>();

        foreach (ShipEnemyMovement enemy in FindObjectsOfType<ShipEnemyMovement>())
        {
            float distance = Vector3.Distance(enemy.transform.position, playerShip.transform.position);

            if (distance < distanceToPlayer)
            {
                distanceToPlayer = distance;
            }
            Destroy(gameObject);
        }

        foreach (ShipEnemyMovement enemy in FindObjectsOfType<ShipEnemyMovement>())
        {
            float distance = Vector3.Distance(enemy.transform.position, playerShip.transform.position);

            if (distance == distanceToPlayer)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}