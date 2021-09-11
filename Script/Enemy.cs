using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health=10;
    public float speed;
    private Animator animator;
    public GameObject bloodEffect;
    public GameObject player;
    public Transform groundDetection;
    public bool moveleft =true;
    public float distance=2.0f;
     public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsplayer;
    public int damage;
    private float timeBtwAttack=1f;
    public float startTimeBtwAttack=2f;
    protected float deadtime=1f;
    //protected bool damagetaken;
    void Start()
    {   
        animator= GetComponent<Animator>();
        animator.SetInteger("AnimState", 2);   
        //player=GetComponent<GameObject>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {   
        timeBtwAttack-=Time.deltaTime;
        //damagetaken =false;
        if(health<=0){
        animator.SetTrigger("Death");
        deadtime-=Time.deltaTime;
        if(transform.CompareTag("boss")){
            Boss.flag1=true;  
        }
        if(deadtime<=0){
        Destroy(gameObject);}
        }
        if(Boss.flag2 &&health<5){
            if(transform.CompareTag("boss")){
            health=15;
            Boss.flag2=false;
            Debug.Log(health);}
        }
        if(health>0){
        transform.Translate( Vector2.left*speed*Time.deltaTime);}
        //transform.position=Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        RaycastHit2D groundInfo =Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
        if(groundInfo.collider == false){
            if(moveleft== true){
                transform.eulerAngles= new Vector3(0,-180,0);
                moveleft=false;
            }
            else{
                transform.eulerAngles= new Vector3(0,0,0);
                moveleft=true;
            }
        }
        attack();
        if(transform.position.y<-50){
            health=-1;
            if(gameObject.CompareTag("boss")==true){
                Boss.flag1=true;
            }
            else{
            Destroy(gameObject);}
        }
    }
    public void TakeDamage(int damage){
        Instantiate(bloodEffect,transform.position+ new Vector3(0,1,0),Quaternion.Euler(0,0,180));
        health-=damage;
        Debug.Log("damage Taken");
        //damagetaken=true;
    }
    public void attack(){
        if((transform.position-player.transform.position).sqrMagnitude<1){
            if(timeBtwAttack<0){
            animator.SetTrigger("Attack");
            Collider2D[] playertodestroy=Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsplayer);
            for(int i =0;i<playertodestroy.Length;i++){
                    //playertodestroy[i].GetComponent<Enemy>().TakeDamage(damage);
                    //Camera.main.GetComponent<CameraShake>().isshakeCamera=true;
                    
                    if(!Bandit.m_combatIdle){HealthBar.healthCur-=damage;

                    Bandit.m_animator.SetTrigger("Hurt");}
                }
            timeBtwAttack=startTimeBtwAttack;
            }
        }
    }
    public void InitEnemy(GameObject _target){
        player=_target;
    }
    void OnDrawGizmosSelected() {
            Gizmos.color =Color.yellow;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }
}
