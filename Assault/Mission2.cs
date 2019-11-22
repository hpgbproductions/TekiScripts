using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;
using Assets.Scripts.Callsign;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission2 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 2 - Ustlensky";
    private static readonly string LevelMap = "Ustlensky";
    private static readonly string LevelDescription =
        "Mission 2" + Environment.NewLine +
        "Area: Ustlensky" + Environment.NewLine +
        "Time: 1400" + Environment.NewLine +
        "Weather: Overcast" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy enemy ships" + Environment.NewLine +
        "- Do not destroy the cargo ship" + Environment.NewLine +
        Environment.NewLine +
        "According to intelligence, there is an enemy weapons factory and base upstream of the Olenyok River. You are to assist the naval combat team by destroying enemy ships in the area." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 2x Missile Boat" + Environment.NewLine +
        "- 1x CIWS Destroyer" + Environment.NewLine +
        "- 3x Destroyer" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Missile Boat" + Environment.NewLine +
        "A flat-deck ship with two missile launchers mounted onto it, making a once harmless ship a serious threat. Destruction is counted when the hull is destroyed. Remember that missile launchers stay operational even after the ship is critically damaged.";

    private static readonly string LevelGameObjectName = "MISSION_2A_SCRIPTS";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission2()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "You are clear for takeoff. Fly out and engage the ships at the coast.";
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
            return "The cargo to protect was destroyed.";
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
            return 14;
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.Overcast;
        }
    }
}