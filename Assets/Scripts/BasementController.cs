using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementController : MonoBehaviour
{
    [SerializeField] float secondsToLoad;
    LevelLoader levelLoader;
    AudioSource gameOverAudio;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        gameOverAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameOver)
        {
            gameOver = true;
            StartCoroutine(GameOverStatus());
        }
    }

    IEnumerator GameOverStatus()
    {
        AudioSource.PlayClipAtPoint(gameOverAudio.clip,
            Camera.main.transform.position,
            gameOverAudio.volume);
        yield return new WaitForSeconds(secondsToLoad);
        levelLoader.LoadGameOverScene();
    }
}
