using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControllerX : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRight=true;
    public float maxRight;
    public float minRight;
    public float speed=0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight){
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        if(!isRight){
             transform.Translate(-speed*Time.deltaTime,0,0);
        }
        if(transform.position.x>=maxRight){
            isRight=false;
        }
        if(transform.position.x<=minRight){
            isRight=true;
        }
    }
}

