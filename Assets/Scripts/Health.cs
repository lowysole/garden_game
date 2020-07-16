using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 10;

    [Header("Dead")]
    [SerializeField] AudioClip deadSound;
    [Range(0f,1f)] [SerializeField] float deadVolume;
    [SerializeField] float waitToDead = 1;
    Animator animator;
    LevelController levelController;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        Destroy(GetComponent<Collider2D>());
        animator.SetBool("isDead", true);
        AudioSource.PlayClipAtPoint(deadSound,
            Camera.main.transform.position,
            deadVolume);
        //VFX
        yield return new WaitForSeconds(waitToDead);
        Destroy(gameObject);
    }

}
