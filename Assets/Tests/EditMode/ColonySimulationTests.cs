using NUnit.Framework;

public class ColonySimulationTests
{
    [Test]
    public void AdvanceDay_DeductsCorrectFoodAndWater()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 100,
            startingWater = 110
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 2.2f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        simulation.AdvanceDay();

        Assert.AreEqual(80f, simulation.CurrentFood);
        Assert.AreEqual(88f, simulation.CurrentWater);
        Assert.AreEqual(1, simulation.CurrentDay);
    }

    [Test]
    public void DaysRemaining_IsCalculatedFromStoredResources()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 100,
            startingWater = 110
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 2.2f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        Assert.AreEqual(5f, simulation.FoodDaysRemaining);
        Assert.AreEqual(5f, simulation.WaterDaysRemaining);
    }

    [Test]
    public void Colony_IsStarving_WhenEitherReserveReachesZero()
    {
        PopulationData populationData = new PopulationData
        {
            villagers = 10,
            startingFood = 20,
            startingWater = 110
        };

        ConsumptionData consumptionData = new ConsumptionData
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 2.2f
        };

        ColonySimulation simulation =
            new ColonySimulation(populationData, consumptionData);

        Assert.IsFalse(simulation.IsStarving);

        simulation.AdvanceDay();

        Assert.IsTrue(simulation.IsStarving);
        Assert.AreEqual(0f, simulation.CurrentFood);
    }
}