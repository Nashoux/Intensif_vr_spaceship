using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPos : MonoBehaviour
{
    public Transform snapToThis;
    public Vector3 posIfNoObject;

    public bool instaSnap = true;
    public bool destroyAfterSnap = true;

    public bool parentToTransform = true;

    // Start is called before the first frame update
    void Start()
    {
        if(parentToTransform && snapToThis != null ){
            transform.parent = snapToThis;
        }
        

        Snap();
    }

    // Update is called once per frame
    void Update()
    {
        Snap();
    }

    void Snap(){
        if(snapToThis != null){
            if(instaSnap){
                transform.position = snapToThis.position;
                transform.rotation = snapToThis.rotation;
            }else{
                
            }
            
            if(destroyAfterSnap && transform.position == snapToThis.position){
                Destroy(this);
            }
        }else{
            if(instaSnap){
                transform.position = posIfNoObject;
            }else{
                
            }
            if(destroyAfterSnap && transform.position == posIfNoObject){
                Destroy(this);
            }
        }

        if(destroyAfterSnap){
            Destroy(this);
        }
    }
}
