using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionIfOut : MonoBehaviour
{

    Vector3 poseBase;
    Quaternion rotBase;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        poseBase = transform.position;
        rotBase = transform.rotation;
        if(GetComponent<Rigidbody>()){
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, ManageScene.player.position) > 4f && Vector3.Distance(transform.position,poseBase) > 0.3f){
            transform.position = poseBase;
            transform.rotation = rotBase;
            if(rb != null){
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
