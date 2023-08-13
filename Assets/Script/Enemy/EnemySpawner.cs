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
    private bool canSpawnEnemies = true;

    private readonly List<ShipEnemyMovement> _enemies = new List<ShipEnemyMovement>();

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private RectTransform _formationRect;
    [SerializeField] private Button _destroyButton;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private float _bonusSpawnChance;
    [SerializeField] private float _bonusMoveSpeed = 100f;

    private float _lastBonusSpawnTime;
    private InvadersMoving _moving;


    private void Start()
    {
        Time.timeScale = 0;

        _moving = new InvadersMoving();

        _destroyButton.onClick.AddListener(ClearEnemies);
    }

    private void OnDestroy()
    {
        _destroyButton.onClick.RemoveListener(ClearEnemies);
    }

    public void CreateEnemyFormation()
    {
        if (canSpawnEnemies)
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

                    ShipEnemyMovement enemyMovement = enemy.GetComponent<ShipEnemyMovement>();
                    ProjectileSpawner projectileSpawner = enemy.GetComponent<ProjectileSpawner>();

                    enemyMovement.Init(_moving);
                    projectileSpawner.Init(_canvas);

                    _enemies.Add(enemyMovement);
                }
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
    public void SetEnemySpeed(float speed)
    {
        foreach (ShipEnemyMovement enemy in _enemies)
        {
            enemy.SetMoveSpeed(speed);
        }
    }

    public void SpawnBonus(Vector3 enemyPosition)
    {
        if (_bonusPrefab != null && CanSpawnBonus())
        {
            GameObject bonus = Instantiate(_bonusPrefab, enemyPosition, Quaternion.identity, _canvas.transform);
            BonusMovement bonusMovement = bonus.GetComponent<BonusMovement>();
            if (bonusMovement != null)
            {
                bonusMovement.Init(_bonusMoveSpeed);
            }
            _lastBonusSpawnTime = Time.time;
        }
    }

    private bool CanSpawnBonus()
    {
        return Time.time - _lastBonusSpawnTime >= 20f;
    }
}