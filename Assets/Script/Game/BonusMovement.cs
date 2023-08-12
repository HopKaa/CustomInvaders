using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private float _moveSpeed;

    public void Init(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}
