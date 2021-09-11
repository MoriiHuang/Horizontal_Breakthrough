using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControllerY : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isUP=true;
    public float maxUP;
    public float minUP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUP){
            transform.Translate(0,0.5f*Time.deltaTime,0);
        }
        if(!isUP){
             transform.Translate(0,-0.5f*Time.deltaTime,0);
        }
        if(transform.position.y>=maxUP){
            isUP=false;
        }
        if(transform.position.y<=minUP){
            isUP=true;
        }
    }
}
