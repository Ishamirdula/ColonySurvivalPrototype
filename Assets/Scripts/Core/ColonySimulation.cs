using System;

public class ColonySimulation
{
    private readonly int villagers;
    private readonly float foodPerVillagerPerDay;
    private readonly float waterPerVillagerPerDay;
    private readonly float secondsPerGameDay;

    private float currentFood;
    private float currentWater;
    private int currentDay;
    private float elapsedSeconds;

    public ColonySimulation(
        PopulationData populationData,
        ConsumptionData consumptionData,
        float secondsPerGameDay = 1f)
    {
        villagers = populationData.villagers;

        currentFood = populationData.startingFood;
        currentWater = populationData.startingWater;

        foodPerVillagerPerDay =
            consumptionData.foodPerVillagerPerDay;

        waterPerVillagerPerDay =
            consumptionData.waterPerVillagerPerDay;

        this.secondsPerGameDay = secondsPerGameDay;

        currentDay = 0;
        elapsedSeconds = 0f;
    }

    private float DailyFoodConsumption
    {
        get { return villagers * foodPerVillagerPerDay; }
    }

    private float DailyWaterConsumption
    {
        get { return villagers * waterPerVillagerPerDay; }
    }

    public bool Tick(float deltaTime)
    {
        if (IsStarving)
        {
            return false;
        }

        elapsedSeconds += deltaTime;

        if (elapsedSeconds < secondsPerGameDay)
        {
            return false;
        }

        elapsedSeconds -= secondsPerGameDay;
        AdvanceDay();
        return true;
    }

    public void AdvanceDay()
    {
        currentDay++;

        currentFood -= DailyFoodConsumption;
        currentWater -= DailyWaterConsumption;

        currentFood = Math.Max(0f, currentFood);
        currentWater = Math.Max(0f, currentWater);
    }

    public float FoodDaysRemaining
    {
        get
        {
            if (DailyFoodConsumption <= 0) return 0;
            return currentFood / DailyFoodConsumption;
        }
    }

    public float WaterDaysRemaining
    {
        get
        {
            if (DailyWaterConsumption <= 0) return 0;
            return currentWater / DailyWaterConsumption;
        }
    }

    public bool IsStarving
    {
        get { return currentFood <= 0 || currentWater <= 0; }
    }

    public float CurrentFood { get { return currentFood; } }
    public float CurrentWater { get { return currentWater; } }
    public int CurrentDay { get { return currentDay; } }

    public float DailyFoodConsumptionValue { get { return DailyFoodConsumption; } }
    public float DailyWaterConsumptionValue { get { return DailyWaterConsumption; } }
}