using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ColonySimulation simulation;

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
}