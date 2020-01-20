using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableResetPosAfter : OVRGrabbable
{

    public Transform transformToReset;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity){
        base.GrabEnd(Vector3.zero,Vector3.zero);
        transform.position = transformToReset.position;
        transform.rotation = transformToReset.rotation;

        Rigidbody rbHandle = transformToReset.GetComponent<Rigidbody>();
        rbHandle.velocity = Vector3.zero;
        rbHandle.angularVelocity = Vector3.zero;
    }

    private void Update() {
        if(Vector3.Distance(transformToReset.position,transform.position) > 0.4f){
            grabbedBy.ForceRelease(this);
            transform.position = transformToReset.position;
            transform.rotation = transformToReset.rotation;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Rigidbody rbHandle = transformToReset.GetComponent<Rigidbody>();
            //rbHandle.velocity = Vector3.zero;
            //rbHandle.angularVelocity = Vector3.zero;
        }
    }


}
