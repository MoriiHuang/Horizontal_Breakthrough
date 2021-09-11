using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : Bandit
{   
    private Rigidbody2D rb;
    public float dashSpeed;
    public float startdashtime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d"))
        t2 = Time.realtimeSinceStartup;
            if (t2 - t1 < 0.2f)
            {
                if(Input.GetKey(KeyCode.W))
                {
                    m_speed*=3;
                }
                Debug.Log("双击");
            }
            t1 = t2;
    }
}
