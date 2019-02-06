using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSpell : MonoBehaviour
{

    public BulletProp[] SpellCodex;


    public BulletProp ThisBullet;

    // Start is called before the first frame update
    void Start()
    {
        ThisBullet = SpellCodex[0];
    }

    private void LateUpdate()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > ThisBullet.nextFire)
        {
            ThisBullet.nextFire = Time.time + ThisBullet.fireRate;
            Instantiate(ThisBullet.bullet, ThisBullet.bulletSpawn.position, ThisBullet.bulletSpawn.rotation);
        }
    }


    //Use this method in the future for finding a new bullet from the array and making it 0
    void ChangeBullet()
    {

    }
}
