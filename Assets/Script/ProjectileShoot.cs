using UnityEngine;
public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    private GameObject _currentProjectile;
    private Canvas _canvas;

    public void Init(Canvas canvas)
    {
        _canvas = canvas;
    }

    private void Update()
    {
        if (_currentProjectile == null && Input.GetKeyDown(KeyCode.Space))
        {
            _currentProjectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            if (_canvas != null)
            {
                _currentProjectile.transform.SetParent(_canvas.transform, false);
            }
        }
    }
}