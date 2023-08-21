using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    public List<Item> item;

    [SerializeField]
    private Item item1;

    /*void Update()
    {
        item.Add(item1);
        Debug.Log(item[0]);
    }*/
}
