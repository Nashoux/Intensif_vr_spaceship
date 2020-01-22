using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    [SerializeField] Transform playerPrivate;
    public static Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = playerPrivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
