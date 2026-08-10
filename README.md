# Colony Survival Prototype

The prototype simulates a colony's food and water reserves over time using values loaded from JSON configuration files.

## Features

* Population, starting food, and starting water loaded from `population.json`.
* Food and water consumption rates loaded from `consumption.json`.
* 1 real second = 1 game day.
* Food and water decrease according to:
  `villagers × consumption per villager per day`
* Displays current food, current water, days remaining, and game day.
* Displays `COLONY STARVING` when either resource reaches zero.
* Core simulation logic is implemented in plain C# without `MonoBehaviour` or `UnityEngine`.
* Includes EditMode unit tests for the simulation logic.

## Unity Version

**Unity 2022.3.62f1**

## How to Run

1. Open the project in Unity 2022.3.62f1.
2. Open the main scene.
3. Press **Play**.
4. The simulation advances automatically at 1 game day per real second.

## Configuration

The prototype uses:

**population.json**

```json
{
    "villagers": 10,
    "startingFood": 370,
    "startingWater": 470
}
```

**consumption.json**

```json
{
    "foodPerVillagerPerDay": 1.85,
    "waterPerVillagerPerDay": 2.35
}
```

I selected reasonable example values using WHO water-intake guidance and FAO nutrition guidance as references. These were simplified into 2.35 L of water and 1.85 food units per villager per game day. Starting reserves were calculated to provide approximately 20 days of resources.

## Tests

Tests are located in the EditMode test folder.

To run them:

**Window → General → Test Runner → EditMode → Run All**

The tests verify resource consumption, days remaining, time advancement, and starvation.

## Architecture

Unity-specific responsibilities are kept in `MonoBehaviour` classes such as `GameManager`, `JsonLoader`, and `ColonyUIController`.

The simulation logic is contained in the plain C# `ColonySimulation` class, including:

* Resource consumption
* Days remaining
* Time advancement
* Starvation detection

## AI Tools Used

ChatGPT and Claude was used as a development assistant for understanding the task, planning the architecture, reviewing C# code, designing unit tests, and preparing documentation.

The Unity project setup, scene configuration, integration, testing, and final implementation decisions were completed and verified by me.

## Decisions & Trade-offs

* The JSON files were not included with the assignment, so reasonable example values were selected and documented.
* The values were chosen to make the simulation reach the starving state at approximately Day 20 for an easy demo.
* The prototype intentionally uses simple Unity UI and does not include art, sound, animations, seasons, buildings, population growth, or other features outside the requested scope.

## Demo

A short demo video shows:
- Food and water reserves decreasing
- Days remaining decreasing
- Game-day counter advancing
- The `COLONY STARVING` state triggering

Demo video: [(https://drive.google.com/file/d/1nabmnENLRhvLnABFsCyZm9WPl2QbEYBk/view?usp=sharing)]
