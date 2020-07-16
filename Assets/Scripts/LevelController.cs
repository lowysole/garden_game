using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    int enemiesAlive = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        enemiesAlive ++;
    }

    public void AttackerDied()
    {
        enemiesAlive --;
        if (levelTimerFinished && enemiesAlive <= 0)
        {
            Debug.Log("Level Finished");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
