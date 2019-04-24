using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSpell : MonoBehaviour
{
    //Areas used for special spells
    public Transform doubleshotTop;
    public Transform doubleshotBot;
    private bool doubleshotCounter = false;



    public List<BulletProp> SpellCodex;
    

    public BulletProp StandardBullet;
    public BulletProp SpellBullet;

    // Start is called before the first frame update
    void Start()
    {
        StandardBullet = SpellCodex[0];
        SpellBullet = SpellCodex[1];

    }

    //Use this method in the future for finding a new bullet from the array and making it 1
    public void ChangeBullet(string spellStolen)
    {
        foreach (BulletProp spell in SpellCodex)
        {
            if (spell.spellName == spellStolen)
            {
                SpellCodex.Remove(spell);
                SpellCodex.Insert(1, spell);
            }
            else
            {

            }
        }
    }

    private void LateUpdate()
    {
        
        
        
    }

    // Update is called once per frame
    // bullet specialities: doubleshot
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > StandardBullet.nextFire)
        {


            StandardBullet.nextFire = Time.time + StandardBullet.fireRate;
            Instantiate(StandardBullet.bullet, StandardBullet.bulletSpawn.position, StandardBullet.bulletSpawn.rotation);
                
            
            
        }
        else if (Input.GetKey(KeyCode.C) && Time.time > SpellBullet.nextFire)
        {
            if (SpellBullet.special != "")
            {
                SpecialBullet();
            }
            else
            {
                SpellBullet.nextFire = Time.time + SpellBullet.fireRate;
                Instantiate(SpellBullet.bullet, SpellBullet.bulletSpawn.position, SpellBullet.bulletSpawn.rotation);

            }

        }
    }


    

    void SpecialBullet()
    {
        switch (SpellBullet.special)
        {
            //Shoots a bullet from the head then the feet
            case "doubleshot":
                SpellBullet.nextFire = Time.time + SpellBullet.fireRate;
                if (doubleshotCounter == false)
                { Instantiate(SpellBullet.bullet, doubleshotTop.position, doubleshotTop.rotation);
                    doubleshotCounter = true;
                }
                else
                { Instantiate(SpellBullet.bullet, doubleshotBot.position, doubleshotBot.rotation);
                    doubleshotCounter = false;
                }
                break;
        }
    }
}
