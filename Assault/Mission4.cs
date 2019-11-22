using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission4 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 4 - Faddeya";
    private static readonly string LevelMap = "Faddeya_MissionVer";
    private static readonly string LevelDescription =
        "Mission 4" + Environment.NewLine +
        "Area: Faddeya" + Environment.NewLine +
        "Time: 0800" + Environment.NewLine +
        "Weather: Broken Clouds" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objectives:" + Environment.NewLine +
        "- Destroy all TGTs" + Environment.NewLine +
        "- Do not destroy the Mobile Landing Pad" + Environment.NewLine +
        Environment.NewLine +
        "Destroy all hostile targets at the separatist supply station. Controlling this location will prevent possible enemy reinforcements from further up the coast. The Mobile Landing Pad in the fleet contains some important weapons cargo we can capture, so do not destroy it." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 4x Long Range Missile Launcher" + Environment.NewLine +
        "- 4x Destroyer" + Environment.NewLine +
        "- 1x Missile Boat" + Environment.NewLine +
        "- 2x AA Tank" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Long Range Missile Launcher" + Environment.NewLine +
        "These missile launchers are singly installed with a radar behind them. This gives the launchers a blind spot where they cannot attack your aircraft, or defend against your missiles.";

    private static readonly string LevelGameObjectName = "MISSION_3_SCRIPTS_TestVer";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission4()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "You are cleared for takeoff.";
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
            return "The weapons cargo to capture was destroyed.";
        }
    }

    protected override string DefendFail2Message
    {
        get
        {
            return "...Huh.";
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
            return "You have ran out of time.";
        }
    }

    protected override float TimerCountdown
    {
        get
        {
            return 1200;
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
            return 8;
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