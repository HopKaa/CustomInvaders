using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _moveSpeed = 500f;
    private PointManager _pointManager;

    private void Start()
    {
        _pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }
    private void Update()
    {
        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            _pointManager.UpdateScore(50);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
