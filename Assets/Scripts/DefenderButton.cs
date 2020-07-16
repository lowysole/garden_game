using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    DefenderSpawner defenderSpawner;
    // Start is called before the first frame update
    void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ChangeColor();
        defenderSpawner.SetDefender(defenderPrefab);
    }

    private void ChangeColor()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(87, 87, 87, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
