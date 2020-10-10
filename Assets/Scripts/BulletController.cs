using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public BulletManagerScript bulletManager;
    public float verticalSpeed;

    public float verticalBoundary;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0, verticalSpeed, 0);
    }

    private void _CheckBounds()
    {
        if(transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
