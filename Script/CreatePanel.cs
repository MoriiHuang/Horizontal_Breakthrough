using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreatePanel : MonoBehaviour
{
    public Button create;
    public Button character1;
    public Button character2;
    public InputField name1;
    public Transform mRoot;
    private GameObject character1obj;
    private GameObject character2obj;
    void Start()
    {   HealthBar.healthCur=20;
        mRoot = transform;
        //character1=mRoot.Find("Rawimage/character1").GetComponent<Button>() as Button;
        //character2=mRoot.Find("Rawimage/character2").GetComponent<Button>() as Button;
        //create=mRoot.Find("Rawimage/create").GetComponent<Button>() as Button;
        //name1=mRoot.Find("Rawimage/Text/name").GetComponent<InputField>() as InputField;
        character1.onClick.AddListener(character1Click);
        character2.onClick.AddListener(character2Click);
        create.onClick.AddListener(createClick);
    }

    private void character1Click(){
        if(character1obj ==null){
        GameObject obj =GameManager.Instance.LoadResources<GameObject>(GameDefine.character1Path);
        character1obj = GameObject.Instantiate(obj);
        character1obj.transform.position = new Vector3(0,0,1);
        }
        else{
            character1obj.SetActive(true);
        }
        if(character2obj !=null){
            //character2obj.SetActive(false);
            Destroy(character2obj);
        }
        PlayerPrefs.SetInt(GameDefine.playerRole,(int)CharacterType.character1);
    }
    private void character2Click(){
        if(character2obj ==null){
        GameObject obj =GameManager.Instance.LoadResources<GameObject>(GameDefine.character2Path);
        character2obj = GameObject.Instantiate(obj);
        character2obj.transform.position = new Vector3(0,0,1);
        }
        else{
            character2obj.SetActive(true);
        }
        if(character1obj !=null){
            //character1obj.SetActive(false);
            Destroy(character1obj);
        }
        PlayerPrefs.SetInt(GameDefine.playerRole,(int)CharacterType.character2);
    }
    private void createClick(){
        GameManager.Instance.LoadScence("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

