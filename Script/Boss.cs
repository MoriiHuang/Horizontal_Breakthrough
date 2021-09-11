using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Start is called before the first frame update
    public GameObject child;
    public Animator m_animator;
    public float attackstart;
    public float attacktime;
    bool flag=true;
    public GameObject End;
    public static bool flag1=false;
    public static bool flag2=true;
    void Start()
    {   
        m_animator=child.GetComponent<Animator>();
        flag1=false;
        //Debug.Log(gameObject.tag);
        //Debug.Log(gameObject.CompareTag("boss"));
    }
    void Update()   
    {   
        attacktime-=Time.deltaTime;
        /*if(4<health && health<7){
            flag2=true;
            Debug.Log(flag2);
            Debug.Log(damagetaken);
        }
        if(flag2 && damagetaken){
            health+=2;
            flag2=false;
            Debug.Log(health);
        }*/
        if(health<5){
            child.SetActive(true);
            if(flag){
                child.transform.Translate(1f*Time.deltaTime,0,0);
            }
            if(!flag){
                child.transform.Translate(-1f*Time.deltaTime,0,0);
            }
            if((child.transform.position-transform.position).sqrMagnitude>8){
                flag=false;
            }
            if((child.transform.position-transform.position).sqrMagnitude<1){
                flag=true;
            }
            m_animator.SetTrigger("throw");
            //child.transform.Translate(-0.5f,0,0);
            if((child.transform.position-player.transform.position).sqrMagnitude<1){
                if(attacktime<=0){
                HealthBar.healthCur-=10f;
                Bandit.m_animator.SetTrigger("Hurt");}
                attacktime=attackstart;
            }
        }
        /*if(flag1){
            End.SetActive(true);
            //flag1=true;  
        }*/
        if(flag1){
                //Boss.flag1=true;
            End.SetActive(true);
            //Debug.Log(Boss.flag1);
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
      //child.transform.Translate(-0.5f,0,0);  
    }
}

