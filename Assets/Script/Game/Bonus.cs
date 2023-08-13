using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private BonusType bonusType;
    private Sprite icon;
    private float effectDuration;

    private System.Random random;

    private void Start()
    {
        random = new System.Random();
    }
    public void ActivateBonusEffect()
    {
        int randomIndex = random.Next(0, Enum.GetValues(typeof(BonusType)).Length - 1);
        BonusType randomBonusType = (BonusType)randomIndex;

        switch (randomBonusType)
        {
            case BonusType.SpeedUp:
                PlayerInputControler playerMovement = FindObjectOfType<PlayerInputControler>();
                if (playerMovement != null)
                {
                    playerMovement.ApplySpeedBoost(effectDuration);
                }
                break;
            case BonusType.TripleShot:
                ProjectileShoot projectileShoot = FindObjectOfType<ProjectileShoot>();
                if (projectileShoot != null)
                {
                    projectileShoot.ActivateTripleShot(effectDuration);
                }
                break;
            case BonusType.DestroyLine:
                DestroyLine();
                break;
            default:
                break;
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

    public enum BonusType
{
    SpeedUp,
    TripleShot,
    DestroyLine
}