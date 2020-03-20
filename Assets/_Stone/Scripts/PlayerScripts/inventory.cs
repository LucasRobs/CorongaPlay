using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace _Stone.Player.Inventory
{
    public class inventory : MonoBehaviour
    {
        public static inventory instance { get; private set; }
        public Dictionary<int, Item.ItemBase> itemList = new Dictionary<int, Item.ItemBase>();

        private void Start()
        {
            instance = this;
        }


        internal void AddItem(Item.ItemBase item)
        {
            if (!itemList.ContainsValue(item))
            {
                itemList.Add(item.ID, item);
            }
            else
            {
                if (itemList[item.ID].CurrentAmount < item.MaxAmount)
                {
                    itemList[item.ID].CurrentAmount++;
                }
            }
        }
    }

}
