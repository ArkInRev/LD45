using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickup : Interactable
{
    protected GameController gc;
    [SerializeField]
    protected ParticleSystem collectPS;

    public AudioSource sound;
    public AudioClip soundClip;

    private IEnumerator coroutine;
     
    public override void Start()
    {
        gc = GameController.instance;
        this.GetComponent<SphereCollider>().radius = GetPickupRange();
    }

    public override void Update()
    {
        base.Update();


    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name + " Tag: " + other.tag);
        if (other.CompareTag("Player"))
        {

            coroutine = playPickupSound();
            StartCoroutine(coroutine);


            Instantiate(collectPS, transform.position, Quaternion.identity);
            gc.UpdateSpirit(1);
            Destroy(gameObject);
        }
    }

    public IEnumerator playPickupSound()
    {
        yield return new WaitForSeconds(0.1f);
        sound.Play();
        
    }


}
