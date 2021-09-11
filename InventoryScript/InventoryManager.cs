using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager:MonoBehaviour
{
    private static InventoryManager Instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot SlotPrefab;
    public Text itemInfo;

    void Awake() {
        if(Instance!=null){
            Destroy(this);
        }
        Instance=this;
    }
    void OnEnable()
    {
        Refresh();
        Instance.itemInfo.text="";
    }
    public static void UpdateItemInfo(string itemDescription){
        Instance.itemInfo.text=itemDescription;
    }
    public static void CreateNewItem(Item item){
        Slot newItem =Instantiate(Instance.SlotPrefab,Instance.slotGrid.transform.position,Quaternion.identity);
        //Debug.Log(Instance.slotGrid.transform.position);
        //Debug.Log(newItem.transform.localScale);
        newItem.transform.localScale = new Vector3(0.005f,0.005f,1);
        Debug.Log(newItem.transform.localScale);
        newItem.gameObject.transform.SetParent(Instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotImage.sprite=item.itemImage;
        newItem.slotnum.text=item.itemHeld.ToString();
    }
    public static void Refresh(){
        for(int i=0;i<Instance.slotGrid.transform.childCount;i++){
            if(Instance.slotGrid.transform.childCount==0){
                break;
            }
            Destroy(Instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for(int i=0;i<Instance.myBag.itemList.Count;i++){
            CreateNewItem(Instance.myBag.itemList[i]);
        }
    }
    public static void Zero(){
        for(int i=0;i<Instance.slotGrid.transform.childCount;i++){
            if(Instance.slotGrid.transform.childCount==0){
                break;
            }
            Destroy(Instance.slotGrid.transform.GetChild(i).gameObject);
            if(Instance.myBag.itemList.Count!=0){ 
            Instance.myBag.itemList[i].itemHeld=0;}
        }
        Instance.myBag.itemList.Clear();
    }
}
