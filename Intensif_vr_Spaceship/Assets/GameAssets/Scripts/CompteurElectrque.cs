using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurElectrque : LeverHolder , Activated
{

    public SwitchCompteur[] mySwitchsNormal;
    public Renderer[] mySwitchsLights;
    public Renderer[] mySwitchsLightsSoluce;

    public List<SwitchCompteur> mySwitchsActive = new List<SwitchCompteur>();
    public List<SwitchCompteur> mySwitchsOrder = new List<SwitchCompteur>();

    public bool iseReseting;
    float timerReset;

    public Transform boxSoluce;

    public GameObject handleToGet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(iseReseting){
            timerReset -=Time.deltaTime;
            if(timerReset <= 0){
                iseReseting = false;
            }
        }   
    }

    public void Activate(GameObject origin){
        SwitchCompteur added = origin.GetComponent<SwitchCompteur>();
        mySwitchsActive.Add(added);
        

        if(isItRight() && isActive){
            
            if(mySwitchsActive.Count >= 3){
                winThis();
            }
        }else{
            StartCoroutine(resetAfter());
            timerReset = 3f;
        }
        iseReseting = true;
        timerReset = 0.2f;
        Debug.Log(isItRight());
    }

    IEnumerator resetAfter(){
        yield return new WaitForSeconds(0.2f);
        ResetCompteur();
        yield return null;
    }

    void winThis(){
        boxSoluce.transform.Rotate(new Vector3(-64.659f,0,0));
        handleToGet.SetActive(true);
    }

    void ResetCompteur(){        
        for(int i = 0; i < mySwitchsActive.Count; i ++){
            mySwitchsActive[i].GetComponent<Animator>().SetBool("Active", false);
            mySwitchsActive[i].GetComponent<Collider>().enabled = true;
        }
        mySwitchsActive.Clear();
    }



    bool isItRight(){
        bool result = true;
            if(mySwitchsActive[mySwitchsActive.Count-1].gameObject.name != mySwitchsOrder[mySwitchsActive.Count-1].gameObject.name){
                result = false;
            }
        return result;
    }
}
