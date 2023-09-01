using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private bool _tripleShotActive;

    private GameObject _currentProjectile;
    private Canvas _canvas;
    private float _tripleShotDuration;

    public void Init(Canvas canvas)
    {
        _canvas = canvas;
    }

    private void Update()
    {
        if (!_currentProjectile && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }

        if (_tripleShotActive && Time.time >= _tripleShotDuration)
        {
            DeactivateTripleShot();
        }
    }

    private void SpawnProjectile()
    {
        if (_tripleShotActive)
        {
            SpawnTripleShotProjectiles();
        }
        else
        {
            SpawnSingleProjectile();
        }
    }

    private void SpawnTripleShotProjectiles()
    {
        Quaternion leftRotation = Quaternion.Euler(0, 0, 30);
        Quaternion rightRotation = Quaternion.Euler(0, 0, -30);

        _currentProjectile = Instantiate(_projectilePrefab, transform.localPosition, Quaternion.identity);
        ShootProjectile();

        _currentProjectile = Instantiate(_projectilePrefab, transform.localPosition, leftRotation);
        ShootProjectile();

        _currentProjectile = Instantiate(_projectilePrefab, transform.localPosition, rightRotation);
        ShootProjectile();
    }

    private void SpawnSingleProjectile()
    {
        _currentProjectile = Instantiate(_projectilePrefab, transform.localPosition, Quaternion.identity);
        _currentProjectile.transform.SetParent(_canvas.transform, false);
    }

    private void ShootProjectile()
    {
        _currentProjectile.transform.SetParent(_canvas.transform, false);
    }

    public void ActivateTripleShot(float duration)
    {
        _tripleShotActive = true;
        _tripleShotDuration = Time.time + duration;
        Invoke("DeactivateTripleShot", duration);
    }

    private void DeactivateTripleShot()
    {
        _tripleShotActive = false;
    }
}