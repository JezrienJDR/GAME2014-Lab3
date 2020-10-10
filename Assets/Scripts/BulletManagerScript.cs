using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManagerScript : MonoBehaviour
{
    public GameObject bullet;

    public int maxBullets;

    private Queue<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildBulletPool()
    {
        bulletPool = new Queue<GameObject>();

        for(int count= 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            bulletPool.Enqueue(tempBullet);
        }
    }


    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        newBullet.transform.parent = transform;

        return newBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        bulletPool.Enqueue(returnedBullet);
    }
}
