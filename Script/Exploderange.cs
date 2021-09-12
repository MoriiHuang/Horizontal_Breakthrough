using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploderange : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public float detoryTime;
    void Start()
    {
        Destroy(gameObject,detoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hao");
        if(other.gameObject.CompareTag("Enemy")){
            other.GetComponent<Enemy>().TakeDamage(damage*2);
        }
        if(other.gameObject.CompareTag("boss")){
            other.GetComponent<Boss>().TakeDamage(damage);
            Debug.Log(other);
        }
         if(other.gameObject.CompareTag("Player")){
            HealthBar.healthCur-=damage;
            Bandit.m_animator.SetTrigger("Hurt");
        }

    }
}
