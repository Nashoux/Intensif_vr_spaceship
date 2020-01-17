using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] bool statutUpdated = false;
    public string cardName = "Card1";
    [SerializeField] Renderer myRender;

    [SerializeField] ButtonRoom button;

    void OnTriggerEnter(Collider other) {
        if(other.tag == cardName && !statutUpdated){
            myRender.material.color = new Color(0.2f,0.8f,0.3f,1f);
            statutUpdated = true;
            button.Activate(this.gameObject);
        }
    }

}
