using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private float _effectDuration = 10f;

    private PlayerInputControler _playerMovement;
    private ProjectileShoot _projectileShoot;
    private ShipEnemyMovement[] _enemies;
    private PlayerShip _playerShip;

    public void Init(PlayerInputControler playerMovement, ProjectileShoot projectileShoot, ShipEnemyMovement[] enemies, PlayerShip playerShip)
    {
        _playerMovement = playerMovement;
        _projectileShoot = projectileShoot;
        _enemies = enemies;
        _playerShip = playerShip;
    }

    public void ActivateBonusEffect()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enum.GetValues(typeof(BonusType)).Length - 1);
        BonusType randomBonusType = (BonusType)randomIndex;

        switch (randomBonusType)
        {
            case BonusType.SpeedUp:
                ApplySpeedUp();
                break;
            case BonusType.TripleShot:
                ApplyTripleShot();
                break;
            case BonusType.DestroyLine:
                DestroyLine();
                break;
            default:
                break;
        }
    }

    private void ApplySpeedUp()
    {
        if (_playerMovement != null)
        {
            _playerMovement.ApplySpeedBoost(_effectDuration);
        }
    }

    private void ApplyTripleShot()
    {
        if (_projectileShoot != null)
        {
            float tripleShotDuration = 10f;
            _projectileShoot.ActivateTripleShot(tripleShotDuration);
        }
    }

    private void DestroyLine()
    {
        if (_enemies.Length > 0 && _playerShip != null)
        {
            float lowestY = Mathf.Infinity;
            ShipEnemyMovement closestEnemy = null;

            foreach (ShipEnemyMovement enemy in _enemies)
            {
                if (enemy.transform.position.y < lowestY)
                {
                    lowestY = enemy.transform.position.y;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                closestEnemy.DestroyEnemy();
            }
        }
    }
}