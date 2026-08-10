using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ColonySimulation simulation;

    [SerializeField] private ColonyUIController uiController;

    private void Start()
    {
        JsonLoader jsonLoader = GetComponent<JsonLoader>();

        PopulationData populationData =
            jsonLoader.LoadPopulationData();

        ConsumptionData consumptionData =
            jsonLoader.LoadConsumptionData();

        simulation =
            new ColonySimulation(
                populationData,
                consumptionData
            );

        uiController.UpdateUI(simulation);
    }

    private void Update()
    {
        if (simulation == null) return;

        if (simulation.Tick(Time.deltaTime))
        {
            uiController.UpdateUI(simulation);
        }
    }
}