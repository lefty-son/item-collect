using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeCalculator {

    private static readonly int[] FORGE_PROB_TABLE = new int[] {100, 100, 100, 93, 85, 76, 66, 55, 43, 30, 16, 8};
    private static readonly float[] FORGE_COST_TABLE = new float[] {0.08f, 0.09f, 0.1f, 0.11f, 0.11f, 0.12f, 0.13f, 0.15f, 0.18f, 0.22f, 0.27f, 0.33f };
    private static readonly float[] RESULT_PRICE_TABLE = new float[] {1.0f, 1.1f, 1.2f, 1.3f, 1.47f, 1.71f, 2.17f, 2.87f, 3.87f, 5.2f, 6.89f, 9f, 11.55f};

	// Forge probability
    public static int GetProbability(int i){
        return FORGE_PROB_TABLE[i];
    }

    // Forge cost
    public static int GetCost(int i, int price)
    {
        return (int)(price * FORGE_COST_TABLE[i]);
    }

    public static int GetCurrentPrice(int i, int price)
    {
        return (int)(price * RESULT_PRICE_TABLE[i]);
    }

    public static int GetNextPrice(int i, int price){
        return (int)(price * RESULT_PRICE_TABLE[i + 1]);
    }

}
