using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUIListener : MonoBehaviour {
    
    public Image i_Outer, i_Inner, i_ItemSprite;
    public Text t_Name, t_CurrentPrice, t_NextPrice, t_ForgePrice, t_ForgeProbability, t_IntervalPrice;
	public Button b_Cancel, b_ForgeIt;
    public GameObject p_OnResult;

    private bool isForgeDone;
    private bool isForgeQueued;
    public Slider slider;


    private GameItem forgeItem;

    public static ForgeUIListener instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        isForgeQueued = false;
        isForgeDone = false;
    }

    private void OnEnable()
    {
        b_Cancel.interactable = true;
        isForgeQueued = false;
        isForgeDone = false;


    }

    public void GetForgeItemFromSlot(GameItem item, Sprite outer, Sprite inner, Color color){
        forgeItem = item;

        // Check affordable
        var isAffordable = CurrencyManager.instance.CheckGoldAffordable(item.GetForgeCostByForgeLevel());
        b_ForgeIt.interactable = isAffordable;

        i_Outer.sprite = outer;
        i_Inner.sprite = inner;
        i_ItemSprite.sprite = item.sprite;
        t_Name.text = item.GetNameByForgeLevel();
        t_Name.color = color;
        t_CurrentPrice.text = item.GetCurrentPriceByForgeLevel().ToString();
        t_NextPrice.text = item.GetNextPriceByForgeLevel().ToString();

        // Set forge cost
        var forgePriceStb = new StringBuilder("-");
        forgePriceStb.Append(item.GetForgeCostByForgeLevel());
        t_ForgePrice.text = forgePriceStb.ToString();



        // Set interval price
        var intervalPriceStb = new StringBuilder("(+");
        intervalPriceStb.Append((item.GetNextPriceByForgeLevel() - item.GetCurrentPriceByForgeLevel()));
        intervalPriceStb.Append(")");
		t_IntervalPrice.text = intervalPriceStb.ToString();

        // Set probabality
        var forgeProbStb = new StringBuilder(ForgeCalculator.GetProbability(item.forgeLevel).ToString());
        forgeProbStb.Append("%");
        t_ForgeProbability.text = forgeProbStb.ToString();
    }

    private void Update()
    {
        if(isForgeQueued && !isForgeDone){
            slider.value += Time.deltaTime;
        }
        if(slider.value >= slider.maxValue && !isForgeDone){
            isForgeDone = true;
            isForgeQueued = false;
            slider.value = 0;
            ShowForgeResult(forgeItem.GetForgeProbabilityByForgeLevel());
        }
    }


#region FORGE INTERACTION

    private void ShowForgeResult(int prob){
        
        CurrencyManager.instance.MinusGoldByValue(forgeItem.GetForgeCostByForgeLevel());
        var r = Random.Range(1, 100);
        UIManager.instance.StartFadeOut();
        p_OnResult.SetActive(true);
        if(r <= prob){
            forgeItem.forgeLevel++;
            OnResultUIListener.instance.GetItemInfoOnSuccess(forgeItem);
        }
        else {
            OnResultUIListener.instance.GetItemInfoOnFail(forgeItem);

            // Remove item
            Inventory.instance.DeleteItem(forgeItem);
        }
        InventoryUIListener.instance.NotifyToSlots();
        gameObject.SetActive(false);
    }

    // FORGE
    public void ForgeIt(){
        b_Cancel.interactable = false;
        b_ForgeIt.interactable = false;
        isForgeQueued = true;
        isForgeDone = false;
    }

#endregion


    private void OnDisable()
	{
		forgeItem = null;
	}
}
