using NUnit.Framework;

public class ColonySimulationTests
{
    [Test]
    public void AdvanceDay_DeductsCorrectFoodAndWater()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 370,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        simulation.AdvanceDay();

        Assert.AreEqual(351.5f, simulation.CurrentFood, 0.001f);
        Assert.AreEqual(446.5f, simulation.CurrentWater, 0.001f);
        Assert.AreEqual(1, simulation.CurrentDay);
    }

    [Test]
    public void DaysRemaining_IsCalculatedFromStoredResources()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 370,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        Assert.AreEqual(20f, simulation.FoodDaysRemaining, 0.001f);
        Assert.AreEqual(20f, simulation.WaterDaysRemaining, 0.001f);
    }

    [Test]
    public void Colony_IsStarving_WhenFoodReachesZero()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 18.5f,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        Assert.IsFalse(simulation.IsStarving);

        simulation.AdvanceDay();

        Assert.IsTrue(simulation.IsStarving);
        Assert.AreEqual(0f, simulation.CurrentFood, 0.001f);
    }

    [Test]
    public void Colony_IsStarving_WhenWaterReachesZero()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 370,
            startingWater = 23.5f
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        Assert.IsFalse(simulation.IsStarving);

        simulation.AdvanceDay();

        Assert.IsTrue(simulation.IsStarving);
        Assert.AreEqual(0f, simulation.CurrentWater, 0.001f);
    }

    [Test]
    public void Tick_ReturnsFalse_BeforeThresholdReached()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 370,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        bool dayPassed = simulation.Tick(0.5f);

        Assert.IsFalse(dayPassed);
        Assert.AreEqual(0, simulation.CurrentDay);
    }

    [Test]
    public void Tick_AdvancesOneDay_OnceThresholdReached()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 370,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        simulation.Tick(0.6f);
        bool dayPassed = simulation.Tick(0.6f);

        Assert.IsTrue(dayPassed);
        Assert.AreEqual(1, simulation.CurrentDay);
        Assert.AreEqual(351.5f, simulation.CurrentFood, 0.001f);
    }

    [Test]
    public void Tick_StopsAdvancing_OnceStarving()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 18.5f,
            startingWater = 470
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 1.85f,
            waterPerVillagerPerDay = 2.35f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        simulation.Tick(1f); // day 1: food lands exactly on 0, starving triggers

        bool dayPassed = simulation.Tick(1f); // should refuse to advance further

        Assert.IsFalse(dayPassed);
        Assert.AreEqual(1, simulation.CurrentDay);
    }
}