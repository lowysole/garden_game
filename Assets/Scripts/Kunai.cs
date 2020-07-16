using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [Range(0f,5f)][SerializeField] float kunaiSpeed = 1f;
    [SerializeField] int damage = 5;

    AudioClip soundHit;
    float soundVolume;

    // Start is called before the first frame update
    void Start()
    {
        soundHit = GetComponent<AudioSource>().clip;
        soundVolume = GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * kunaiSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();
     
        if (!attacker && !health) { return; }
        AudioSource.PlayClipAtPoint(soundHit,
            Camera.main.transform.position,
            soundVolume);
        health.DealDamage(damage);
        Destroy(gameObject);
    }
}
