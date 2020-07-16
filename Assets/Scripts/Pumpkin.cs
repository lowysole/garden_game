using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Stone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");

        }
        else if (otherObject.GetComponent<Defender>())
        { 
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
