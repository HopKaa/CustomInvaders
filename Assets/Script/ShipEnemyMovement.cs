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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boundary>())
        {
            _moving.InvaderTouchBoundary();
        }
    }
}