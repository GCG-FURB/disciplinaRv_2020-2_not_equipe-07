using Assets.Scripts.Targets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [HideInInspector]public bool isOut;
    Animator anim;
    Collider col;

    TargetSet set;

    void Start()
    {
        anim = GetComponent<Animator>();    
        col = GetComponent<Collider>();
        set = gameObject.GetComponentInParent<TargetSet>();
    }

    public void Activate(bool on)
    {
        if(anim != null)
        {
            isOut = on;
            col.enabled = on;

            anim.SetBool("activate", on);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Activate(false);
        set.CheckForReset();
    }
}
