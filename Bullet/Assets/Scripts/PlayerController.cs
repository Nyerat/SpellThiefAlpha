using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class CharacterStats
{
    public float Health;
    public float maxHealth;
    public float Speed;
    public float stealChargeRate;
}

public class PlayerController : MonoBehaviour
{
    CharacterStats PlayerStats = new CharacterStats();

    public Boundary boundary;

    private Rigidbody2D rb2d;

    public float Speed;

    public float GrazeSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    

    private void Update()
    {       
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Grazing speed
            PlayerStats.Speed = GrazeSpeed;
        }
        else
        {
            //Normal speed
            PlayerStats.Speed = Speed;
        }
    }

    void FixedUpdate()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHori, moveVert, 0.0f);
        rb2d.velocity = (movement * PlayerStats.Speed);

        rb2d.position = new Vector3(
            Mathf.Clamp (rb2d.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp (rb2d.position.y, boundary.yMin, boundary.yMax), 
            0.0f
        );

            
    }
}
