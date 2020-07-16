using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            gameObject.GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
