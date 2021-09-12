using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   private Vector2 StartSpeed=new Vector2(4,5);
   private Rigidbody2D rb2D;
   public float delayExplodeTime;
   public float delayDestroyTime;
   public float HItBoxTime;
   private Animator anim;
   public GameObject explodeRange;

    void Start()
    {   
        rb2D=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        if(Bandit.isRight){
        rb2D.velocity=transform.right* StartSpeed.x+transform.up*StartSpeed.y;}
        else{
        rb2D.velocity=transform.right*-StartSpeed.x+transform.up*StartSpeed.y;   
        }
        Invoke("Explode",delayExplodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Explode(){
        anim.SetTrigger("Explode");
        Invoke("DestroyThisBomb",delayDestroyTime);
        Invoke("GenExplodeRange",HItBoxTime);
    }
    void DestroyThisBomb(){
        Destroy(gameObject);
    }
    void GenExplodeRange(){
        Instantiate(explodeRange,transform.position,Quaternion.identity);
    }
}
