using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public Item thisItem;
    public Inventory playerInventory;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem(){
        if(! playerInventory.itemList.Contains(thisItem)){
            playerInventory.itemList.Add(thisItem);
            thisItem.itemHeld=1;
            //InventoryManager.CreateNewItem(thisItem);
        }
        else{
            thisItem.itemHeld+=1;
        }
        InventoryManager.Refresh();
    }
}
