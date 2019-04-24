using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{


    public CharacterStats PlayerStats;
    public EnemyBulletProp EnemyBullet;
    private bool hurtable = true;

    private float damageReceived;
    public GameObject Character;
    public Material damageFizzle;
    public Material normal;
    private Color normalColor;

    public Image healthSprite;
    public Sprite[] healthSprites;


    private void Start()
    {
        normalColor = GetComponent<Renderer>().material.color;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls") || other.CompareTag("StealerObject") || other.CompareTag("PlayerSpell"))
        {
            return;
        }

        if (hurtable == true)
            {
            StartCoroutine(IFramesWhenHurt());
            PlayerStats.Health--;
            ChangeHealth(PlayerStats.Health, PlayerStats.maxHealth);
            if (PlayerStats.Health <= 0)
            {
                Debug.Log("Dead!");
                Destroy(other.gameObject);
            }
            Debug.Log(PlayerStats.Health);
        }
    }


    IEnumerator IFramesWhenHurt()
    {
        hurtable = false;
        for (int i = 0; i < 5; i++)
            {

            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            GetComponent<Renderer>().material.color = normalColor;
            yield return new WaitForSeconds(0.15f);
        }
        hurtable = true;
    }

    public void ChangeHealth(float currentHealth, float maxHealth)
    {
        float percentHealth = (currentHealth / maxHealth) * 100;

        if (percentHealth == 100)
        {
            healthSprite.sprite = healthSprites[0];
        }
        else if (percentHealth >= 80)
        {
            healthSprite.sprite = healthSprites[1];
        }
        else if (percentHealth >= 30)
        {
            healthSprite.sprite = healthSprites[2];
        }
        else if (percentHealth <= 0)
        {
            healthSprite.sprite = healthSprites[3];
        }


    }



}
