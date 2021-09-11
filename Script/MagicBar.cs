using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicBar : MonoBehaviour
{
    public static float MagicCur;
    public static float MagicMax=40; 
    private Image Magicbar;
    public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       Magicbar=GetComponent<Image>();
       //Debug.Log(Magicbar);
       MagicCur=MagicMax;
       player=GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Magicbar.fillAmount =(float)MagicCur/(float)MagicMax;
        //Debug.Log(MagicCur);
        //Debug.Log(Magicbar.fillAmount);
        //healthCur-=(float)0.1*Time.deltaTime;
    }
    public void InitImage(GameObject _target){
        player=_target;
    }
}
