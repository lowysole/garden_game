using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;

    public void AddCredit(int amount)
    {
        FindObjectOfType<CreditDisplay>().AddCredit(amount);
    }

    public int GetCreditCost()
    {
        return cost;
    }
}
