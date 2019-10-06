using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator thisAnimator;
    private NavMeshAgent thisNavMeshAgent;
    private Transform target;

    [SerializeField]
    LayerMask clickLayers;

    [SerializeField]
    private float rotationSpeed = 20f;

    public Interactable focus;

    public Sword equipped;
    
    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        thisNavMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out hit, 100,clickLayers))
            {
                thisNavMeshAgent.destination = hit.point;
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, clickLayers))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    if (interactable.CompareTag("Enemy"))
                    {
                        equipped.DoAttack();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipped.DoAttack();
        }


        if (target != null)
        {
            thisNavMeshAgent.SetDestination(target.position);
            faceTarget();

        }


    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus!=null) focus.OnDefocused();
            focus = newFocus;
        }

        
        newFocus.OnFocused(transform);
        FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if (focus != null) focus.OnDefocused();
        focus = null;
        StopFollowingTarget();
    }

    public void FollowTarget(Interactable newTarget)
    {
        thisNavMeshAgent.stoppingDistance = .9f * newTarget.GetPickupRange();
        thisNavMeshAgent.updateRotation = false;
        target = newTarget.transform;
        

    }

    public void StopFollowingTarget()
    {
        thisNavMeshAgent.stoppingDistance = 0.0f;
        thisNavMeshAgent.updateRotation = true;
        target = null;
    }

    void faceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);

    }
}
