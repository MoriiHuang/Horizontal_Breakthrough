using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Levelmanager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject characterobj;
    private GameObject Enemy0;
    private GameObject Enemyobj;
    public Image image;
    public GameObject[] Enemy;
    public GameObject End;
    public string SceneName;
    void Start()
    {
      CharacterType type= GameManager.Instance.CharacterType;
      string playerResName= string.Empty;
      if(type==CharacterType.character1){
        playerResName=GameDefine.character1Path;
        Bandit.damageplus=3;
        Bandit.damageptmp=3;
    }
      else{
        playerResName=GameDefine.character2Path;
        Bandit.damageplus=2;
        Bandit.damageptmp=2;
    }
    player=GameManager.Instance.LoadResources<GameObject>(playerResName);
    characterobj=GameObject.Instantiate(player);
    characterobj.transform.position=new Vector3(-1/2,-3,-1);
    Camera.main.GetComponent<CameraFollw>().InitCamera(characterobj.transform);
    //image.GetComponent<HealthBar>().InitImage(characterobj);
    HealthBar.player=characterobj;
    MagicBar.player=characterobj;
    for(int i=0;i<Enemy.Length;i++){
    Enemy[i].GetComponent<Enemy>().InitEnemy(characterobj);
    if(i==Enemy.Length-1){
        Enemy[i].GetComponent<Boss>().InitEnemy(characterobj);
    }
    }
   /*Enemy=GameManager.Instance.LoadResources<GameObject>(GameDefine.character2Path);
    Enemyobj=GameObject.Instantiate(Enemy);
    Enemyobj.transform.position =new Vector3(0,-2,-1);*/
    }
    // Update is called once per frame
    void Update()
    {
     if((characterobj.transform.position-End.transform.position).sqrMagnitude<1){
       Debug.Log(Boss.flag1);
      if(Boss.flag1==true){
      GameManager.Instance.LoadScence(SceneName);
      }
    }   
    }
}
