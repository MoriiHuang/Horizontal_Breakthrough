using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName="New Item",menuName="Inventory/New Item")]
public class Item : ScriptableObject
{
   public string itemName;
   public Sprite itemImage;
   public int itemHeld=1;
   [TextArea]
   public string itemInfo;
   void Start()
   {
      itemHeld=1;
   }
}
