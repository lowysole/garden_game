using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 2f)] [SerializeField] float attackSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerDied();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * attackSpeed * Time.deltaTime);
        UpdateAnimatonFrame();
        DisableColition();
    }

    private void DisableColition()
    {
        if (GetComponent<Animator>().GetBool("isDead") == true)
        {
            Destroy(GetComponent<Collider2D>());
        }
    }

    private void UpdateAnimatonFrame()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void setCurrentSpeed(float speed)
    {
        attackSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }


    public void StrikeCurrentTargert(int damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
