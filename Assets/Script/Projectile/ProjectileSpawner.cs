using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private const float _spawnMax = 20;
    private const float _spawnMin = 5;

    [SerializeField] private GameObject _enemyProjectile;
    
    private GameObject _currentBullet;
    private Canvas _canvas;
    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = Random.Range(_spawnMin, _spawnMax);
    }
    public void Init(Canvas canvas)
    {
        _canvas = canvas;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            _currentBullet = Instantiate(_enemyProjectile, transform.localPosition, Quaternion.identity);
            _currentBullet.transform.SetParent(_canvas.transform, false);

            _spawnTimer = Random.Range(_spawnMin, _spawnMax);
        }
    }
}
