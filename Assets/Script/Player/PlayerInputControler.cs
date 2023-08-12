using UnityEngine;

public class PlayerInputControler : MonoBehaviour
{
    private const float MoveSpeed = 300;
    private float _horizontalInput;
    private float _boostedSpeed;
    private float _boostDuration;
    private float _boostTimer;


    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (_boostTimer > 0)
        {
            _boostTimer -= Time.deltaTime;

            if (_boostTimer <= 0)
            {
                _boostedSpeed = 0;
            }
        }

    transform.Translate(Vector2.right* (_horizontalInput* MoveSpeed + _boostedSpeed) * Time.deltaTime);
    }
    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        _boostedSpeed = boostAmount;
        _boostDuration = duration;
        _boostTimer = duration;
    }
}