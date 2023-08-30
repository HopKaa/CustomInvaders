using UnityEngine;
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;

    public void Init(PlayerLives model)
    {
        _playerCollision.Init(model);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bonus>())
        {
            Bonus bonus = collision.GetComponent<Bonus>();
            bonus.ActivateBonusEffect();
            Destroy(collision.gameObject);
        }
    }
}