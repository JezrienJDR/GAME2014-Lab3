using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManagerScript bulletManager;

    private Rigidbody2D rb;

    public float horizontalBoundary;
    public float horizontalSpeed;

    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    void _FireBullet()
    {
        if (Time.frameCount % 40 == 0)
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    private void _Move()
    {
        float direction = 0.0f;

        // Touch input:

        //var touch = Input.touches[0];
        //var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                direction = 1.0f;
            }
            if (worldTouch.x < transform.position.x)
            {
                direction = -1.0f;
            }
        }

        
        //if (worldTouch.x > transform.position.x)
        //{
        //    direction = 1.0f;
        //}
        //if (worldTouch.x < transform.position.x)
        //{
        //    direction = -1.0f;
        //}

        // Keyboard input only:

        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            direction = 1.0f;
        }
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            direction = -1.0f;
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity + new Vector2(direction * horizontalSpeed, 0.0f), maxSpeed);
        rb.velocity *= 0.99f;
    }

    private void _CheckBounds()
    {
        if(transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0);
        }
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0);
        }
    }
}
