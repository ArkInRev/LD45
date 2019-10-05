using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator anim;
    private AnimatorClipInfo[] clip;


    // Start is called before the first frame update
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
        
            


        clip = anim.GetNextAnimatorClipInfo(0);
        Debug.Log(clip[0].clip.name);
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

}
