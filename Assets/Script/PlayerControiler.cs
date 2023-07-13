using UnityEngine;

public class PlayerControiler : MonoBehaviour
{
    private const float _moveSpeed = 300;
    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * _horizontalInput * _moveSpeed  * Time.deltaTime); 
    }
}
