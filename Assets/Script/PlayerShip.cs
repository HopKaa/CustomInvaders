using UnityEngine;
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;

    public void Init(PlayerLives model)
    {
        _playerCollision.Init(model);
    }
}
