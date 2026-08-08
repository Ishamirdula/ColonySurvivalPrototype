using System;

public class ColonySimulation
{
    private readonly int villagers;
    private readonly float foodPerVillagerPerDay;
    private readonly float waterPerVillagerPerDay;

    private float currentFood;
    private float currentWater;
    private int currentDay;

    public ColonySimulation(
        PopulationData populationData,
        ConsumptionData consumptionData)
    {
        villagers = populationData.villagers;

        currentFood = populationData.startingFood;
        currentWater = populationData.startingWater;

        foodPerVillagerPerDay =
            consumptionData.foodPerVillagerPerDay;

        waterPerVillagerPerDay =
            consumptionData.waterPerVillagerPerDay;

        currentDay = 0;
    }

    private float DailyFoodConsumption
    {
        get
        {
            return villagers * foodPerVillagerPerDay;
        }
    }

    private float DailyWaterConsumption
    {
        get
        {
            return villagers * waterPerVillagerPerDay;
        }
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
            if (DailyFoodConsumption <= 0)
            {
                return 0;
            }

            return currentFood / DailyFoodConsumption;
        }
    }

    public float WaterDaysRemaining
    {
        get
        {
            if (DailyWaterConsumption <= 0)
            {
                return 0;
            }

            return currentWater / DailyWaterConsumption;
        }
    }

    public bool IsStarving
    {
        get
        {
            return currentFood <= 0 || currentWater <= 0;
        }
    }

    public float CurrentFood
    {
        get { return currentFood; }
    }

    public float CurrentWater
    {
        get { return currentWater; }
    }

    public int CurrentDay
    {
        get { return currentDay; }
    }
}