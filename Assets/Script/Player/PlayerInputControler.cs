using UnityEngine;

public class PlayerInputControler : MonoBehaviour
{
    private const float MoveSpeed = 300;
    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * _horizontalInput * MoveSpeed  * Time.deltaTime); 
    }
}
