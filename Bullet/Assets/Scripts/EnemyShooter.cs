using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public float EnemyCastTime;
    public EnemyBulletProp[] EnemySpellCodex;


    public EnemyBulletProp EnemyBullet;
    public string spell;


    // Activates before the first frame
    private void Start()
    {

        EnemyBullet = EnemySpellCodex[0];
        
    }

    // Awake activates when the object comes alive
    void Awake()
    {
        StartCoroutine(EnemyAttack());
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(EnemyCastTime);
        Instantiate(EnemyBullet.bullet, EnemyBullet.bulletSpawn.position, EnemyBullet.bulletSpawn.rotation);
        yield return new WaitForSeconds(EnemyCastTime);
        Instantiate(EnemyBullet.bullet, EnemyBullet.bulletSpawn.position, EnemyBullet.bulletSpawn.rotation);
    }
}
