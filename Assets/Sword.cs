﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sword : MonoBehaviour
{
    private Animator anim;
     private AnimatorClipInfo[] clip;
    [SerializeField]
    private float knockbackForce = 25;
    [SerializeField]
    float knockbackSeconds = 2;
    // Start is called before the first frame update
    [SerializeField]
    private float damageCaused = 5.0f;

    private IEnumerator coroutine;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DoAttack()
    {

        if (!anim.GetBool("swing1"))
        {
            anim.SetBool("swing1", true);
        }
        
            


//        clip = anim.GetNextAnimatorClipInfo(0);
//        Debug.Log(clip[0].clip.name);
//            if (clip[0].clip.name == "SwordSwing1")
            if (anim.GetBool("swing1"))
            {
                anim.SetBool("swing1", false);
            anim.SetBool("swing2", true);
            anim.SetBool("swing3", false);
        }

        if (anim.GetBool("swing2"))
        {
                anim.SetBool("swing1", false);
                anim.SetBool("swing2", false);
                anim.SetBool("swing3", true);
            }
        anim.SetTrigger("NormalSwing");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy was hit with the sword. ");
            knockbackEnemy(other);
        } else if (other.CompareTag("Object"))
        {
            knockbackPush(other);
        }
        damageObject(damageCaused,other);
    }

    IEnumerator RestoreControlToNavMeshAgent(Collider enemy)
    {
        yield return new WaitForSeconds(knockbackSeconds);
        if(enemy!=null)
        {
            enemy.GetComponent<NavMeshAgent>().SetDestination(enemy.transform.position);
            enemy.GetComponent<Rigidbody>().isKinematic = true;
            enemy.GetComponent<NavMeshAgent>().updatePosition = true;
        }

    }

    private void knockbackEnemy(Collider enemy)
    {
        NavMeshAgent nma = enemy.GetComponent<NavMeshAgent>();
        enemy.GetComponent<Rigidbody>().isKinematic = false;
        nma.updatePosition = false;
        nma.isStopped = true;
        nma.ResetPath();
        coroutine = RestoreControlToNavMeshAgent(enemy);

        knockbackPush(enemy);
        StartCoroutine(coroutine);

    }

    private void knockbackPush(Collider other)
    {
        Vector3 dir = other.transform.position - transform.position;
        dir = dir.normalized;
        other.GetComponent<Rigidbody>().AddForce(dir * knockbackForce, ForceMode.Impulse);
    }

    private void damageObject(float dmg, Collider other)
    {
        hp otherHP = other.GetComponent<hp>();

        if (otherHP != null)
        {
            otherHP.takeDamage(dmg);
        }
    }

}
