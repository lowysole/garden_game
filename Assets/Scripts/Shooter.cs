using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] Kunai kunai;
    Vector3 kunaiPos = new Vector2(0.4f, 0.2f);

    [Header("Sound")]
    [SerializeField] AudioClip weaponSound;
    [Range(0f, 1f)] [SerializeField] float weaponVolume;

    AttackerSpawner myAttackSpawner;
    Animator animator;


    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
       
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawn in spawners)
        {
            bool isCloseEnought = (
                Mathf.Abs(spawn.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);
            if (isCloseEnought)
            {
                myAttackSpawner = spawn;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myAttackSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        Instantiate(kunai, transform.position + kunaiPos, transform.rotation);
        AudioSource.PlayClipAtPoint(weaponSound,
            Camera.main.transform.position,
            weaponVolume);
    }



}
