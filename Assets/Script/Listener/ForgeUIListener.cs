using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUIListener : MonoBehaviour {
    
    public Image i_Outer, i_Inner, i_ItemSprite;
    public Text t_Name, t_CurrentPrice, t_NextPrice, t_ForgePrice, t_ForgeProbability;

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
        isForgeQueued = false;
        isForgeDone = false;
    }

    public void GetForgeItemFromSlot(GameItem item, Sprite outer, Sprite inner, Color color){
        
        forgeItem = item;
        i_Outer.sprite = outer;
        i_Inner.sprite = inner;
        i_ItemSprite.sprite = item.sprite;
        t_Name.text = item.nameNative;
        t_Name.color = color;
        t_CurrentPrice.text = ForgeCalculator.GetCurrentPrice(item.forgeLevel, item.sellingCost).ToString();
        t_NextPrice.text = ForgeCalculator.GetNextPrice(item.forgeLevel, item.sellingCost).ToString();
        t_ForgePrice.text = ForgeCalculator.GetCost(item.forgeLevel, item.sellingCost).ToString();

        var stb = new StringBuilder(ForgeCalculator.GetProbability(item.forgeLevel).ToString());
        stb.Append("%");
        t_ForgeProbability.text = stb.ToString();
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
            ShowForgeResult(ForgeCalculator.GetProbability(forgeItem.forgeLevel));
        }
    }

    private void ShowForgeResult(int prob){
        var r = Random.Range(1, 100);
        if(r <= prob){
            forgeItem.forgeLevel++;
            Debug.Log("succes");
        }
        else {
            Debug.Log("failed");
        }
    }

    public void ForgeIt(){
        isForgeQueued = true;
        isForgeDone = false;
        Debug.Log("forge spirit.");
    }

	private void OnDisable()
	{
		forgeItem = null;
	}
}
