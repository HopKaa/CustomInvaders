using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyMovement : MonoBehaviour
{
    private float _moveSpeed = 100f;
    private  void Update()
    {
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            _moveSpeed *= -1;
        }
    }
}