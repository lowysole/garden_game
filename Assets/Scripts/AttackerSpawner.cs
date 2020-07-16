using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] attacker;

    bool spawn = true;


    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime,
                maxSpawnTime));
            Spawn();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn()
    {
        int index = Random.Range(0,attacker.Length);

        SpawnAttackers(attacker[index]);
    }

    private void SpawnAttackers(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker,
            transform.position,
            transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
