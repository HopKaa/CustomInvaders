using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float formationWidth = 10f; // ������ �������� ������
    public float formationHeight = 4f; // ������ �������� ������

    private void Start()
    {
        // ����������� �������� ������ �� ������ ������
        Vector3 startPosition = transform.position - new Vector3(formationWidth / 2f, formationHeight / 2f, 0f);
        transform.position = startPosition;
    }
}
