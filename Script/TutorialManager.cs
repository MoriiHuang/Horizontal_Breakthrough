using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpsindex; 
    public GameObject spawner;
    void Update()
    {  
        for(int i =0;i<popUps.Length;i++){
            if(i==popUpsindex){
                popUps[i].SetActive(true);
            }
            else{
                popUps[i].SetActive(false);
            }
        }
        if(popUpsindex==0){
            if(Input.GetKeyDown("a")||Input.GetKeyDown("d")){
                popUpsindex++;
            }
        }
        else if(popUpsindex==2){
            if(Input.GetKeyDown("j")){
                spawner.SetActive(true);
                popUpsindex++;
            }
        }
        else if(popUpsindex==1){
            if(Input.GetKeyDown("space")){
                popUpsindex++;
                Debug.Log(popUpsindex);
            }
        }
    }
}
