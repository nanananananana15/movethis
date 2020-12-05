using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Item grabbingItem;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;
    }

    public Item GetGrabbingItem()
    {
        Item oldItem = grabbingItem;
        grabbingItem = null;
        return oldItem;
    }

    public void SetGrabbingItem(Item item)
    {
        grabbingItem = item;
    }

    public bool IsHavingItem()
    {
        return grabbingItem != null;
    }
}
