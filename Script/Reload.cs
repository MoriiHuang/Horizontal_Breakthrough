using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reload : MonoBehaviour
{   
    public Button replay;
    // Start is called before the first frame update
    void Start()
    {
       replay=transform.GetComponent<Button>();
        replay.onClick.AddListener(replayClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void replayClick(){
        //InventoryManager.Zero();
        GameManager.Instance.LoadScence("UI");
    }
}
