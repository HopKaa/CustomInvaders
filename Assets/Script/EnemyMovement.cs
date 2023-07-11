using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость движения врагов

    private void Update()
    {
        // Движение вниз
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
