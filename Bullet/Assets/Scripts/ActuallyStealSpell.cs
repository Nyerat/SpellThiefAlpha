using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActuallyStealSpell : MonoBehaviour
{
    string spellStolen = "none";
    public GameObject spellthief;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(spellStolen);
        if (other.CompareTag("Enemy"))
        {
            spellStolen = other.GetComponent<EnemyShooter>().spell;
            Debug.Log(spellStolen);
            spellthief.GetComponent<PlayerSpell>().ChangeBullet(spellStolen);
        }
    }



}
