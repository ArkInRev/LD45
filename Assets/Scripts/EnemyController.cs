using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float awareness = 20f;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private CapsuleCollider[] meleeColliders;


    [SerializeField]
    private ParticleSystem playerHitPS;
    [SerializeField]
    private ParticleSystem objectHitPS;

    [SerializeField]
    private float typicalDamage = 3.0f;
    [SerializeField]
    private float damageCaused;

    Transform target;
    NavMeshAgent agent;


    // Attack controls
    [SerializeField]
    private float timeBetweenAttacks;
    private float lastAttackCounter;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player manager player name is: " + PlayerManager.instance.name);
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        damageCaused = typicalDamage;
    }

 
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist <= awareness)
        {
            agent.SetDestination(target.position);

            if (dist <= agent.stoppingDistance)
            {
                faceTarget();

                // Agent is close enough for an attack;
                if (lastAttackCounter <= 0)
                {
                    anim.SetTrigger("DoAttack");
                    lastAttackCounter = timeBetweenAttacks;
                }


            }



        } else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }

        if (lastAttackCounter > 0)
        {
            lastAttackCounter-=Time.deltaTime;
            //anim.ResetTrigger("DoAttack");
        }


    }

    void faceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, awareness);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Enemy was hit with the sword. ");
            Instantiate(playerHitPS, other.ClosestPoint(transform.position), Quaternion.identity);
            //knockbackEnemy(other);
            damageObject(damageCaused, other);
        }
        else if (other.CompareTag("Object"))
        {
            Instantiate(objectHitPS, other.ClosestPoint(transform.position), Quaternion.identity);
            //knockbackPush(other);
            damageObject(damageCaused, other);
        }
        
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
