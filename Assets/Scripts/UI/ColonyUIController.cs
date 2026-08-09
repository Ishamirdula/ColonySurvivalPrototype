using TMPro;
using UnityEngine;

public class ColonyUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text gameDayText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text statusText;

    public void UpdateUI(ColonySimulation simulation)
    {
        gameDayText.text = $"GAME DAY: {simulation.CurrentDay}";

        foodText.text =
            $"FOOD\n{simulation.CurrentFood:F1}\n" +
            $"{simulation.FoodDaysRemaining:F1} DAYS REMAINING";

        waterText.text =
            $"WATER\n{simulation.CurrentWater:F1}\n" +
            $"{simulation.WaterDaysRemaining:F1} DAYS REMAINING";

        statusText.text = simulation.IsStarving
            ? "COLONY STARVING"
            : "COLONY STABLE";
    }
}