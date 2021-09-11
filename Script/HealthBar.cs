using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public static float healthCur;
    public static float healthMax=40; 
    private Image healthbar;
    public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       healthbar=GetComponent<Image>();
       Debug.Log(healthbar);
       healthCur=healthMax;
       player=GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount =(float)healthCur/(float)healthMax;
        healthCur-=(float)0.1*Time.deltaTime;
    }
    public void InitImage(GameObject _target){
        player=_target;
    }
}
