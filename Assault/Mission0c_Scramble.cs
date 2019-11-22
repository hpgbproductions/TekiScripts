using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission0_Scramble : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 0c - Scramble";
    private static readonly string LevelMap = "NullMap";
    private static readonly string LevelDescription =
        "Qualifier: Scramble" + Environment.NewLine +
        "Area: Chaunskaya" + Environment.NewLine +
        "Time: 0900" + Environment.NewLine +
        "Weather: Few Clouds" + Environment.NewLine +
        "Vehicle: Fighter" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy all TGTs within 2 minutes and 30 seconds" + Environment.NewLine +
        Environment.NewLine +
        "New intelligence suggests that there is a possible threat of enemy fighters. Even though their numbers are small, fighter capabilities and teams will now be considered. This mission will focus on close-range aerial combat. Install an anti-aircraft loadout and destroy the drones as quickly as possible." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Air):" + Environment.NewLine +
        "- 4x Drone";

    private static readonly string LevelGameObjectName = "TrainingMission_AirAssault";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission0_Scramble()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "Climb and engage the targets.";
        }
    }

    protected override string SuccessMessage
    {
        get
        {
            return "We're actually part if it this time, no more qualifiers.";
        }
    }

    protected override string DefendFailMessage
    {
        get
        {
            return "Bruh";
        }
    }

    protected override string CriticalDamageMessage
    {
        get
        {
            return "Your aircraft has been critically damaged.";
        }
    }

    protected override string OutOfTimeMessage
    {
        get
        {
            return "The forces aren't satisfied with our team. Try again.";
        }
    }

    protected override float TimerCountdown
    {
        get
        {
            return 150;
        }
    }

    protected override bool TimerEnabled
    {
        get
        {
            return true;
        }
    }

    protected override bool StartTimerWithThrottle
    {
        get
        {
            return false;
        }
    }

    protected override int TimeOfDay
    {
        get
        {
            return 9;
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.FewClouds;
        }
    }
}