using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private const int _rows = 3;
    private const int _enemiesPerRow = 6;
    private const float _distanceBetweenEnemies = 100f;
    private const float _distanceBetweenRows = 100f;
    private const float _spawnOffset = 300f;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private RectTransform _formationRect;
    [SerializeField] private Button _destroyButton;

    private InvadersMoveng _moveng;

    private void Start()
    {
        _moveng = new InvadersMoveng();
        _destroyButton.onClick.AddListener(DestroyEnemies);
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

                enemy.GetComponent<ShipEnemyMovement>().Init(_moveng);
            }
        }
    }

    public void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        CreateEnemyFormation();
    }
}