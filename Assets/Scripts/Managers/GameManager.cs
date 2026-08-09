using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ColonySimulation simulation;
    private float dayTimer;

    [SerializeField] private ColonyUIController uiController;

    private void Start()
    {
        JsonLoader jsonLoader = GetComponent<JsonLoader>();

        PopulationData populationData =
            jsonLoader.LoadPopulationData();

        ConsumptionData consumptionData =
            jsonLoader.LoadConsumptionData();

        simulation =
            new ColonySimulation(populationData, consumptionData);

        uiController.UpdateUI(simulation);
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

            uiController.UpdateUI(simulation);

        }
    }
}