using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // �������� �������� ������

    private void Update()
    {
        // �������� ����
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
