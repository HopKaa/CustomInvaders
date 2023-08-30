using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private float _effectDuration = 10f;

    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
    }
    public void ActivateBonusEffect()
    {
        int randomIndex = _random.Next(0, Enum.GetValues(typeof(BonusType)).Length - 1);
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
        PlayerInputControler playerMovement = FindObjectOfType<PlayerInputControler>();
        if (playerMovement != null)
        {
            playerMovement.ApplySpeedBoost(_effectDuration);
        }
    }

    private static void ApplyTripleShot()
    {
        ProjectileShoot projectileShoot = FindObjectOfType<ProjectileShoot>();
        if (projectileShoot != null)
        {
            float tripleShotDuration = 10f;
            projectileShoot.ActivateTripleShot(tripleShotDuration);
        }
    }

    private void DestroyLine()
    {
        ShipEnemyMovement[] enemies = FindObjectsOfType<ShipEnemyMovement>();
        PlayerShip playerShip = FindObjectOfType<PlayerShip>();

        if (enemies.Length > 0 && playerShip != null)
        {
            float lowestY = Mathf.Infinity;
            ShipEnemyMovement closestEnemy = null;

            foreach (ShipEnemyMovement enemy in enemies)
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