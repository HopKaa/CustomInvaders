using UnityEngine;

public class ShipEnemyMovement : MonoBehaviour
{
    private float _moveSpeed = 200f;
    private InvadersMoveng _moveng;
    private bool _hasTriggeredBoundary = false;

    public void Init(InvadersMoveng moven)
    {
        _moveng = moven;
    }

    private void OnMovingChaged()
    {
        if (!_hasTriggeredBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
            _moveSpeed *= -1;
            _hasTriggeredBoundary = true;
        }
    }

    private void Start()
    {
        _moveng.MovingChanged += OnMovingChaged;
    }

    private void OnDestroy()
    {
        _moveng.MovingChanged -= OnMovingChaged;
    }

    private void Update()
    {
        _hasTriggeredBoundary = false;
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            _moveng.InvaderTouchBoundary();
        }
    }
}