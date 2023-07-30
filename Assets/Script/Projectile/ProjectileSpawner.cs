using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private const float _spawnMax = 20;
    private const float _spawnMin = 5;

    [SerializeField] private GameObject _enemyProjectile;
    private GameObject _currentBullet;
    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = Random.Range(_spawnMin, _spawnMax);
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            _currentBullet = Instantiate(_enemyProjectile, transform.position, Quaternion.identity);
            _currentBullet.transform.SetParent(FindObjectOfType<Canvas>().transform);
           
            _spawnTimer = Random.Range(_spawnMin, _spawnMax);
        }
    }
}
