﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIListener : MonoBehaviour {

    public GameObject slotPrefab;
    public List<SlotUIListener> slots;

    private void Start()
    {
        slots = new List<SlotUIListener>();
        MakeSlots();
    }

    private void OnEnable()
    {
        NotifyToSlots();
    }

    public void MakeSlots(){
        var size = PlayerManager.instance.GetStatsBagSize();
        for (int i = 0; i < size; i++){
            GameObject slot = Instantiate(slotPrefab, transform.position, Quaternion.identity, transform);
            slots.Add(slot.GetComponent<SlotUIListener>());
        }
    }

    public void NotifyToSlots(){
        for (int i = 0; i < Inventory.instance.inventory.Count; i++){
            slots[i].OnNotify(Inventory.instance.inventory[i]);
        }
    }
}
