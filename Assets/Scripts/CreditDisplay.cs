using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditDisplay : MonoBehaviour
{
    [SerializeField] int credit = 900;
    Text creditText;

    void Start()
    {
        creditText = GetComponent<Text>();
        UpdateCredit();
    }

    private void UpdateCredit()
    {
        creditText.text = credit.ToString();
    }

    public void AddCredit(int newCredit)
    {
        credit += newCredit;
        UpdateCredit();
    }

    public void SpendCredit(int newCredit)
    {
        credit -= newCredit;
        UpdateCredit();
    }

    public bool CheckCredit(int amount)
    {
        return credit >= amount;
    }  
}
