using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject _currentBullet;
    private void Update()
    {
        if (_currentBullet == null && Input.GetKeyDown(KeyCode.Space))
        {
            _currentBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _currentBullet.transform.SetParent(FindObjectOfType<Canvas>().transform);
        }
    }
}
