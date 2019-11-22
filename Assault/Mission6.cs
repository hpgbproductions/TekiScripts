using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;
using Assets.Scripts.Callsign;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission6 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 6 - Satellite Lab";
    private static readonly string LevelMap = "Taymyr2";
    private static readonly string LevelDescription =
        "Mission 6" + Environment.NewLine +
        "Area: Taymyr Peninsula" + Environment.NewLine +
        "Time: 1500" + Environment.NewLine +
        "Weather: Scattered Clouds" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy all TGTs" + Environment.NewLine +
        "- Do not destroy research buildings" + Environment.NewLine +
        "- Do not fly above 1,500 m (5,000 ft)" + Environment.NewLine +
        Environment.NewLine +
        "We have reached the subject of this combat event. Do all you can to clear the airspace for our capture forces. While it is unfortunate that the technological subject will be damaged, we cannot take the risk of any arrival of enemy reinforcements." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 3x Long Range Missile Launcher" + Environment.NewLine +
        "- 16x Missile Launcher" + Environment.NewLine +
        "- 1x Tunnel" + Environment.NewLine +
        "- 1x Satellite Antenna" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Satellite Dish" + Environment.NewLine +
        "This variant of the humble communications device tests a new, unknown type of transmission system. It is this piece of technology that we are trying to capture this year.";

    private static readonly string LevelGameObjectName = "MISSION_6_SCRIPTS";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission6()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "Sanitize the airspace for our landing forces.";
        }
    }

    protected override string SuccessMessage
    {
        get
        {
            return "Mission accomplished. You will be rewarded for your work.";
        }
    }

    protected override string DefendFailMessage
    {
        get
        {
            return "How.";
        }
    }

    protected override string DefendFail2Message
    {
        get
        {
            return "A research building was destroyed.";
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
            return "Enemy reinforcements have arrived! Retreat!";
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
            return 15;
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