using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHolder : MonoBehaviour
{
    public Transform pos;

    GameObject lastEnteredLever;
    public GameObject grabableHandler;
    int nbLever = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Lever" && other.GetComponent<OVRGrabbable>().isGrabbed == true){
            lastEnteredLever = other.gameObject;
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.tag == "Lever" &&  lastEnteredLever == null && other.GetComponent<OVRGrabbable>().isGrabbed == true){
            lastEnteredLever = other.gameObject;
        }
        if(other.tag == "Lever" && lastEnteredLever != null && other.GetComponent<OVRGrabbable>().isGrabbed == false){
            Destroy(other.GetComponent<OVRGrabbable>());
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<Collider>());
            SnapToPos mySnap = other.gameObject.AddComponent<SnapToPos>();
            mySnap.snapToThis = pos;
            other.tag = "Untagged";
            nbLever ++;
            if(nbLever >= 2){
                grabableHandler.SetActive(true);
                Destroy(this);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Lever"){
            lastEnteredLever = null;
        }
    }


}
