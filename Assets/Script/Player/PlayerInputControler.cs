using UnityEngine;

public class PlayerInputControler : MonoBehaviour
{
    private float _boostSpeed = 500f;
    private float _normalSpeed = 300f;
    private float _moveSpeed;
    private float _horizontalInput;
    private float _boostTimer;

    private void Start()
    {
        _moveSpeed = 300f;
    }
    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (_boostTimer > 0)
        {
            _boostTimer -= Time.deltaTime;

            if (_boostTimer <= 0)
            {
                _moveSpeed = _normalSpeed;
            }
        }

        transform.Translate(Vector2.right * (_horizontalInput * _moveSpeed) * Time.deltaTime);
    }

    public void ApplySpeedBoost( float duration)
    {
        _boostTimer = duration;
        _moveSpeed = _boostSpeed;
    }
}