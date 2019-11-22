using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;
using Assets.Scripts.Callsign;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission0_Mountain : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 0a - Mountain";
    private static readonly string LevelMap = "Chaunskaya";
    private static readonly string LevelDescription =
        "Qualifier: Mountain" + Environment.NewLine +
        "Area: Chaunskaya" + Environment.NewLine +
        "Time: 1200" + Environment.NewLine +
        "Weather: Scattered Clouds" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy all TGTs within 2 minutes and 30 seconds" + Environment.NewLine +
        Environment.NewLine +
        "Take on a speed training mission to prove your piloting skills and your aircraft's worth. Your performance will determine whether your team will be involved in our missions - many teams are vying for a position in the campaign, and we only want the best." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 8x AA Tank (disabled)";

    private static readonly string LevelGameObjectName = "TrainingMission_Mountain";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission0_Mountain()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "You are cleared for takeoff. Turn around and engage the targets.";
        }
    }

    protected override string SuccessMessage
    {
        get
        {
            return "The higher-ups are pleased with our efforts. Good job!";
        }
    }

    protected override string DefendFailMessage
    {
        get
        {
            return "That's one way to fail the mission.";
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

    protected override int TimeOfDay
    {
        get
        {
            return 12;
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.ScatteredClouds;
        }
    }
}