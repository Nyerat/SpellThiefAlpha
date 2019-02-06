using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealSpellScript : MonoBehaviour
{
    public bool isShot;

    public float stealRate;

    public BulletProp spellStealBolt;
    private Rigidbody2D rb2db;
    Vector3 movement = new Vector3(4f, 0.0f, 0.0f);


    public Image thisIcon;
    public Sprite normal;
    public Sprite maxFlash;


    public float coolDown;
    public float coolDownTimer;
    public Slider coolDownSlider;

    public float stealChargeTime;
    public float stealChargeMax;
    public Slider chargeSlider;

    private void Start()
    {
        if (isShot)
        {
            rb2db = GetComponent<Rigidbody2D>();
            rb2db.velocity = (movement * stealChargeTime);
            StartCoroutine(DeleteBoltTimer());
        }
    }

    private void LateUpdate()
    {

        // Code for the Player itself
        if (!isShot)
        { 
            //Cooldown
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }

            //Charge up the shot
            if (coolDownTimer == 0)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    if (stealChargeTime <= stealChargeMax)
                    {
                        stealChargeTime = stealChargeTime + stealRate;
                        Debug.Log(stealChargeTime);
                    }
                }
            }

            //Fire the steal
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (coolDownTimer == 0)
                {
                    FireSteal();
                    if (isShot)
                    {

                    }
                    coolDownTimer = coolDown;
                }
                stealChargeTime = 0f;
                //Flash the icon
                StartCoroutine(Flash());
            }

            chargeSlider.value = stealChargeTime;
            coolDownSlider.value = coolDownTimer;

        }

        
    }

    //UI Code
    IEnumerator Flash()
    {

        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.15f);
            thisIcon.sprite = maxFlash;
            yield return new WaitForSeconds(0.15f);
            thisIcon.sprite = normal;
        }





    }

    //Code to delete the bolt after time
    IEnumerator DeleteBoltTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }


    //Take Charge time and apply a velocity to the steal
    void FireSteal()
    {

        GameObject stealInstance = Instantiate(spellStealBolt.bullet, spellStealBolt.bulletSpawn.position, spellStealBolt.bulletSpawn.rotation);
        stealInstance.GetComponent<StealSpellScript>().SetSpeed(stealChargeTime);
        //spellStealBolt = stealInstance.GetComponent<BulletProp>();
        //spellStealBolt.bulletSpeed = stealChargeTime;

    }

    void SetSpeed(float chargeSpeed)
    {
        stealChargeTime = chargeSpeed;
    }
}
