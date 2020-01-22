using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLever : MonoBehaviour
{

    public OVRGrabbable handleGrab;
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.eulerAngles.z < 155 && transform.rotation.eulerAngles.z > 145  && !handleGrab.isGrabbed){
            handleGrab.enabled = false;
            door.Activate(this.gameObject);
        }
    }
}
