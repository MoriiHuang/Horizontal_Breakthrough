using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public Item slotItem;
    public Image slotImage;
    public Text slotnum;
    private float usetime=10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usetime-=Time.deltaTime;
    }
    public void ItemOnClicked(){
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        if(slotItem.itemName=="shoe"){
            usetime=180;
            if(usetime>0){
                Bandit.extrajumpplus=3;
            }
        }
        if(slotItem.itemName=="Sword"){
            usetime=30;
            if(usetime>0){
                Bandit.damageplus=6;
            }
        }
        slotItem.itemHeld-=1;
        InventoryManager.Refresh();
    }
}
