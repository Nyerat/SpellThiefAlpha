using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class HurtByContact : MonoBehaviour
{
    public BulletProp ThisBullet;
    
    private float damageDealt;

    

    public float Health;

    private void Start()
    {

    }

    private void LateUpdate()
    {


        if (Health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Stops from deleting enemys and ignores walls as collision
        if (other.CompareTag("Walls") || (other.CompareTag("Enemy")))
        {
            return;
        }

        // Registers damage from the Player and Enemy being hit
        if (other.gameObject.tag == "PlayerSpell" && ThisBullet.isPassthrough == false)
        {
            damageDealt = other.GetComponent<BoltMover>().ThisBullet.bulletDamage;
            Destroy(other.gameObject);
            Health -= damageDealt;
        }
        else if (other.gameObject.tag == "PlayerSpell")
        {
            Health -= damageDealt;
        }

        
    }

    
}
