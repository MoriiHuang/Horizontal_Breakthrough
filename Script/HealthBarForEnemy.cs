using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarForEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthCur;
    public float healthMax; 
    private Image healthbar;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       healthbar=GetComponent<Image>();
       healthCur=healthMax;
       //player=GetComponent<GameObject>();
       healthMax=player.GetComponent<Enemy>().health;
    }

    // Update is called once per frame
    void Update()
    {
        healthCur=player.GetComponent<Enemy>().health;
        healthbar.fillAmount =(float)healthCur/(float)healthMax;
        //healthCur-=(float)0.1*Time.deltaTime;
    }
    public void InitImage(GameObject _target){
        player=_target;
    }
}