using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIListener : MonoBehaviour {

    public static InventoryUIListener instance;


    public GameObject slotPrefab;
    public List<SlotUIListener> slots;

	private void Awake()
	{
		if (instance == null) instance = this;
	}

    private void Start()
    {
        slots = new List<SlotUIListener>();
        MakeSlots();
    }

    private void OnEnable()
    {
        if(slots.Count == 0){
            MakeSlots();
        }
        NotifyToSlots();
    }

    public void MakeSlots(){
        var size = PlayerManager.instance.GetStatsBagSizeValue();
        for (int i = 0; i < size; i++){
            GameObject slot = Instantiate(slotPrefab, transform.position, Quaternion.identity, transform);
            slots.Add(slot.GetComponent<SlotUIListener>());
        }
    }

    public void InactiveAllHolders(){
        foreach(var item in slots){
            item.InactiveAllHolders();
        }
    }

    public void NotifyToSlots(){
        InactiveAllHolders();
        for (int i = 0; i < Inventory.instance.inventory.Count; i++){
            slots[i].OnNotify(Inventory.instance.inventory[i]);
        }
    }
}
