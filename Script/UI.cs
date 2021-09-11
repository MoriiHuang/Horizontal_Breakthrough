using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{   private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
       startButton = transform.GetComponent<Button>();
       startButton.onClick.AddListener(StartClick); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartClick(){
        GameManager.Instance.LoadScence("CreatePanel");
    }
}
