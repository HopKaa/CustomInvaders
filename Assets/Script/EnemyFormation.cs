using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float formationWidth = 10f; // Ширина формации врагов
    public float formationHeight = 4f; // Высота формации врагов

    private void Start()
    {
        // Располагаем формацию врагов по центру экрана
        Vector3 startPosition = transform.position - new Vector3(formationWidth / 2f, formationHeight / 2f, 0f);
        transform.position = startPosition;
    }
}
