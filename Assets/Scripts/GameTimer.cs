using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeLevel = 10;
    bool triggeredLevelFinished = false;
 
    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / timeLevel;
        bool timerFinished = (Time.timeSinceLevelLoad >= timeLevel);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }

    }

}
