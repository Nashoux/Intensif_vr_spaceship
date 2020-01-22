using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCompteur : MonoBehaviour
{
    public CompteurElectrque compteurElectrque;
    public Collider myCollider;
    public Animator animator;
    void Start()
    {
        myCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Active(){
        if(!compteurElectrque.iseReseting){
            compteurElectrque.Activate(this.gameObject);
            myCollider.enabled = false;
            animator.SetBool("Active", true);
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Hand"){
            Active();
        }
    }
}
