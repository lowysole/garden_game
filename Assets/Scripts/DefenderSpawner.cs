using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        AttemptSpawn(GetSquareClicked());
    }

    public void SetDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptSpawn(Vector2 pos)
    {
        var creditDisplay = FindObjectOfType<CreditDisplay>();
        int defenderCost = defender.GetCreditCost();
        if (creditDisplay.CheckCredit(defenderCost))
        {
            SpawnDefender(pos);
            creditDisplay.SpendCredit(defenderCost);

        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x,
            Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 pos)
    {
        Defender spawnDefender = Instantiate(defender,
            pos,
            Quaternion.identity) as Defender;
    }
}
