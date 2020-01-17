using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRoom : MonoBehaviour, Activated
{
    
    public bool isOpening = false;

    [SerializeField] Door door;

    void Start()
    {
        
    }

    public void Activate(GameObject origin){
        isOpening = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Hand"){
            if(isOpening){
                door.Activate(this.gameObject);
            }else{

            }
        }
    }
}
