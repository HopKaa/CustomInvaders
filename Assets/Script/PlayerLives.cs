using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    private int _lives = 3;
    [SerializeField] private Image[] _livesUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            _lives -= 1;

            for (int i = 0; i < _livesUI.Length; i++)
            {
                if (i < _lives)
                {
                    _livesUI[i].enabled = true;
                }
                else
                {
                    _livesUI[i].enabled = false;
                }
            }

            if (_lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
