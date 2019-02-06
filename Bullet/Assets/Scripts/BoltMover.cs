using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletProp
{
    public GameObject bullet;
    public float bulletSpeed = 5;
    public float fireRate;
    public float nextFire;
    public float bulletDamage;
    //Gameobject that knows to pull it's transform
    public Transform bulletSpawn;

    public bool isPassthrough;

}

public class BoltMover : MonoBehaviour
{

    

    public BulletProp ThisBullet = new BulletProp();

    private Rigidbody2D rb2db;
    Vector3 movement = new Vector3(1f, 0.0f, 0.0f);

    


    // Start is called before the first frame update
    void Start()
    {
        rb2db = GetComponent<Rigidbody2D>();
        rb2db.velocity = (movement * ThisBullet.bulletSpeed);
        
}

    // Update is called once per frame
    void Update()
    {
        
    }

    //Use this method in the future for finding a new bullet from the array and making it 0
    void ChangeBullet()
    {

    }
}
