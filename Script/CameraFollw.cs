using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollw : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 Distance;
    public void InitCamera(Transform _target){
        target=_target;
        Distance=transform.position-target.position;
    }
    void Start()
    {   
       
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position=target.position+Distance;
    }
}
