using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int _rows = 3;
    private const int _enemiesPerRow = 6;
    private const float _distanceBetweenEnemies = 100f;
    private const float _distanceBetweenRows = 100f;
    private const float _spawnOffset = 300f;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private RectTransform _formationRect;
    private void Start()
    {
        CreateEnemyFormation();
    }

    private void CreateEnemyFormation()
    {
        Vector2 startPosition = _formationRect.anchoredPosition;

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _enemiesPerRow; col++)
            {
                Vector2 enemyPosition = startPosition + new Vector2(col * _distanceBetweenEnemies, row * -_distanceBetweenRows + _spawnOffset);

                GameObject enemy = Instantiate(_enemyPrefab, _formationRect);
                RectTransform enemyRect = enemy.GetComponent<RectTransform>();
                enemyRect.anchoredPosition = enemyPosition;
            }
        }
    }
}
