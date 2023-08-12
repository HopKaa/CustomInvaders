using Unity.VisualScripting;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public BonusType bonusType;
    public Sprite icon;
    public float effectDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateBonusEffect();

            Destroy(gameObject);
        }
    }
    private void ActivateBonusEffect()
    {
        switch (bonusType)
        {
            case BonusType.SpeedUp:
                PlayerInputControler playerMovement = FindObjectOfType<PlayerInputControler>();
                if (playerMovement != null)
                {
                    playerMovement.ApplySpeedBoost(1000f, 10f);
                }
                break;
            /*case BonusType.Invincibility:
                PlayerLives playerHealth = FindObjectOfType<PlayerLives>();
                if (playerHealth != null)
                {
                    playerHealth.ActivateInvincibility(20f);
                }
                break;*/
            default:
                break;
        }
    }

}

public enum BonusType
{
    SpeedUp,
    Invincibility
}

