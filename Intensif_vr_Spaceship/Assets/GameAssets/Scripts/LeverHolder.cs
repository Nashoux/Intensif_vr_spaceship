using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHolder : MonoBehaviour
{
    public Transform pos;

    GameObject lastEnteredLever;
    public GameObject grabableHandler;

    public GameObject[] handlesToAdd;
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
            other.GetComponent<OVRGrabbable>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Collider>().enabled = false;
            other.gameObject.SetActive(false);
            SnapToPos mySnap = other.gameObject.AddComponent<SnapToPos>();
            mySnap.snapToThis = pos;
            other.tag = "Untagged";
            handlesToAdd[nbLever].SetActive(true);
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
