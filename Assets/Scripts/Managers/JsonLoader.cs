using System.IO;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public PopulationData LoadPopulationData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "population.json");
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<PopulationData>(json);
    }

    public ConsumptionData LoadConsumptionData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "consumption.json");
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<ConsumptionData>(json);
    }
}