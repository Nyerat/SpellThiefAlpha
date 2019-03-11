using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSpell : MonoBehaviour
{
    //Areas used for special spells
    public Transform doubleshotTop;
    public Transform doubleshotBot;
    private bool doubleshotCounter = false;



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
    // bullet specialities: doubleshot
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > ThisBullet.nextFire)
        {
            if (ThisBullet.special != "")
            {
                SpecialBullet();
            }
            else
            {
                ThisBullet.nextFire = Time.time + ThisBullet.fireRate;
                Instantiate(ThisBullet.bullet, ThisBullet.bulletSpawn.position, ThisBullet.bulletSpawn.rotation);
            }

        }
    }


    //Use this method in the future for finding a new bullet from the array and making it 0
    void ChangeBullet()
    {

    }

    void SpecialBullet()
    {
        Debug.Log("test");
        switch (ThisBullet.special)
        {
            case "doubleshot":
            ThisBullet.nextFire = Time.time + ThisBullet.fireRate;
                if (doubleshotCounter == false)
                { Instantiate(ThisBullet.bullet, doubleshotTop.position, doubleshotTop.rotation);
                    doubleshotCounter = true;
                }
                else
                { Instantiate(ThisBullet.bullet, doubleshotBot.position, doubleshotBot.rotation);
                    doubleshotCounter = false;
                }
                break;
        }
    }
}
