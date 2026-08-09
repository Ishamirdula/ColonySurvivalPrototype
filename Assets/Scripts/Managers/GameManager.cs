using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ColonySimulation simulation;
    private float dayTimer;

    private void Start()
    {
        JsonLoader jsonLoader = GetComponent<JsonLoader>();

        PopulationData populationData =
            jsonLoader.LoadPopulationData();

        ConsumptionData consumptionData =
            jsonLoader.LoadConsumptionData();

        simulation =
            new ColonySimulation(populationData, consumptionData);
    }

    private void Update()
    {
        if (simulation == null || simulation.IsStarving)
        {
            return;
        }

        dayTimer += Time.deltaTime;

        if (dayTimer >= 1f)
        {
            dayTimer -= 1f;

            simulation.AdvanceDay();

            Debug.Log(
                $"Game Day: {simulation.CurrentDay} | " +
                $"Food: {simulation.CurrentFood} | " +
                $"Water: {simulation.CurrentWater} | " +
                $"Starving: {simulation.IsStarving}"
            );
        }
    }
}