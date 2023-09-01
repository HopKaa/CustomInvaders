using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private RectTransform _formationRect;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private float _bonusMoveSpeed = 100f;
    [SerializeField] private PauseMenu _pauseMenu;

    private float _lastBonusSpawnTime;
    private CommonInvadersMovingEvent _moving;


    private void Start()
    {
        _moving = new CommonInvadersMovingEvent();
    }

    public void CreateEnemyFormation()
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

    public bool IsAlive()
    {
        return _enemies.Any(enemy => enemy);
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

    public void DestroyEnemy()
    {
        float distanceToPlayer = Mathf.Infinity;
        PlayerShip playerShip = _playerShip;

        foreach (ShipEnemyMovement enemy in _enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, playerShip.transform.position);

            if (distance < distanceToPlayer)
            {
                distanceToPlayer = distance;
            }
            Destroy(gameObject);
        }

        foreach (ShipEnemyMovement enemy in _enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, playerShip.transform.position);

            if (distance == distanceToPlayer)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}