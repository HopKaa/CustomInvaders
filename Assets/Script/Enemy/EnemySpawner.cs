using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private const int Rows = 3;
    private const int EnemiesPerRow = 6;
    private const float DistanceBetweenEnemies = 100f;
    private const float DistanceBetweenRows = 100f;
    private const float SpawnOffset = 300f;

    private readonly List<ShipEnemyMovement> _enemies = new List<ShipEnemyMovement>();

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private RectTransform _formationRect;
    [SerializeField] private Button _destroyButton;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Canvas _canvas;

    private InvadersMoving _moving;

    private void Start()
    {
        _moving = new InvadersMoving();

        _destroyButton.onClick.AddListener(ClearEnemies);
    }

    private void OnDestroy()
    {
        _destroyButton.onClick.RemoveListener(ClearEnemies);
    }

    private void CreateEnemyFormation()
    {
        Vector2 startPosition = _formationRect.anchoredPosition;

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < EnemiesPerRow; col++)
            {
                Vector2 enemyPosition = startPosition + new Vector2(col * DistanceBetweenEnemies, row * -DistanceBetweenRows + SpawnOffset);

                GameObject enemy = Instantiate(_enemyPrefab, _formationRect);
                RectTransform enemyRect = enemy.GetComponent<RectTransform>();
                enemyRect.anchoredPosition = enemyPosition;

                enemy.GetComponent<ShipEnemyMovement>().Init(_moving);
                enemy.GetComponent<ProjectileSpawner>().Init(_canvas);


                _enemies.Add(enemy.GetComponent<ShipEnemyMovement>());
            }
        }
    }

    private void ClearEnemies()
    {
        foreach (ShipEnemyMovement enemy in _enemies)
        {
            Destroy(enemy.gameObject);
        }

        _enemies.Clear();

        EnemyProjectile[] enemyProjectiles = FindObjectsOfType<EnemyProjectile>();
        foreach (EnemyProjectile enemyProjectile in enemyProjectiles)
        {
            Destroy(enemyProjectile.gameObject);
        }

        CreateEnemyFormation();

        Time.timeScale = 1;
        _gameOverText.text = string.Empty;
    }

    public bool IsAlive()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy)
            {
                return true;
            }
        }

        return false;
    }
}