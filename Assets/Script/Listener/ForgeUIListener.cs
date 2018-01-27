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
        i_Outer.sprite = outer;
        i_Inner.sprite = inner;
        i_ItemSprite.sprite = item.sprite;
        t_Name.text = item.GetNameByForgeLevel();
        t_Name.color = color;
        t_CurrentPrice.text = item.GetCurrentPriceByForgeLevel().ToString();
        t_NextPrice.text = item.GetNextPriceByForgeLevel().ToString();

        var forgePriceStb = new StringBuilder("-");
        forgePriceStb.Append(item.GetForgeCostByForgeLevel());
        t_ForgePrice.text = forgePriceStb.ToString();

        var intervalPriceStb = new StringBuilder("(+");
        intervalPriceStb.Append((item.GetNextPriceByForgeLevel() - item.GetCurrentPriceByForgeLevel()));
        intervalPriceStb.Append(")");
		t_IntervalPrice.text = intervalPriceStb.ToString();

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

    private void ShowForgeResult(int prob){
        var r = Random.Range(1, 100);
        UIManager.instance.StartFadeOut();
        p_OnResult.SetActive(true);
        if(r <= prob){
            forgeItem.forgeLevel++;
            OnResultUIListener.instance.GetItemInfoOnSuccess(forgeItem);
        }
        else {
            OnResultUIListener.instance.GetItemInfoOnFail(forgeItem);
        }
        InventoryUIListener.instance.NotifyToSlots();
        gameObject.SetActive(false);
    }

    public void ForgeIt(){
        b_Cancel.interactable = false;
        isForgeQueued = true;
        isForgeDone = false;
    }

	private void OnDisable()
	{
		forgeItem = null;
	}
}
