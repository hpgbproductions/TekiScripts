using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;
using Assets.Scripts.Callsign;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission1 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 1 - Lyakhovsky";
    private static readonly string LevelMap = "Lyakhovsky";
    private static readonly string LevelDescription =
        "Mission 1" + Environment.NewLine +
        "Area: Lyakhovshy" + Environment.NewLine +
        "Time: 1100" + Environment.NewLine +
        "Weather: Broken Clouds" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy the anti-ship missile launchers" + Environment.NewLine +
        Environment.NewLine +
        "Separatists have installed automated anti-ship missile launchers in the Lyakhovsky Islands. Our strategists have identified a path of least resistance through the area. You are to clear the area ahead of our fleet." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 4x Anti-Ship Missile Launcher" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Anti-Ship Missile Launcher" + Environment.NewLine +
        "Automated installations with medium range missiles, designed to take down entire fleets. Each launcher has two SAMs and a missile interception system for self-defense. Destruction is counted when both of its barrels (marked Missile Launcher) are destroyed.";

    private static readonly string LevelGameObjectName = "MISSION_1_SCRIPTS";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission1()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "Destroy all four anti-ship missile launchers on the coast.";
        }
    }

    protected override string SuccessMessage
    {
        get
        {
            return "Mission accomplished, return for landing.";
        }
    }

    protected override string DefendFailMessage
    {
        get
        {
            return "Ouch, how could you do this?";
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
            return "The launchers have acquired our fleet!";
        }
    }

    protected override float TimerCountdown
    {
        get
        {
            return 600;
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
            return 11;
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.BrokenClouds;
        }
    }
}