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
        gameDayText.text =
            $"GAME DAY : {simulation.CurrentDay}";

        foodText.text =
            $"FOOD\n\n" +
            $"{simulation.CurrentFood:F1} units\n" +
            $"{simulation.FoodDaysRemaining:0} Days Remaining";

        waterText.text =
            $"WATER\n\n" +
            $"{simulation.CurrentWater:F1} L\n" +
            $"{simulation.WaterDaysRemaining:0} Days Remaining";

        statusText.text = simulation.IsStarving
            ? "COLONY STARVING"
            : "COLONY STABLE";
    }
}