using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Activated
{
    bool opened = false;
    void Start()
    {
        
    }

    public void Activate(GameObject origin){
        if(!opened){
            GetComponent<Animator>().SetTrigger("Open");
            opened = true;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
