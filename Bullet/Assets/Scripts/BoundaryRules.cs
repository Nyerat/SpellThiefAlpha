using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryRules : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
