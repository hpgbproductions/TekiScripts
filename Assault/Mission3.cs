using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission3 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 3 - Anabarsky";
    private static readonly string LevelMap = "Anabarsky";
    private static readonly string LevelDescription =
        "Mission 3-1" + Environment.NewLine +
        "Area: Anabarsky" + Environment.NewLine +
        "Time: 0900" + Environment.NewLine +
        "Weather: Stormy" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objectives:" + Environment.NewLine +
        "- Destroy all TGTs" + Environment.NewLine +
        Environment.NewLine +
        "The separatists have built a tactical laser weapon, designated Polemouth, at Anabarsky. The weapon is close to being operational again, from the previous SAFE. Destroy all ships defending the island to open the Polemouth to attack, and disable it." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 1x Missile Boat" + Environment.NewLine +
        "- 2x CIWS Destroyer" + Environment.NewLine +
        "- 3x Destroyer" + Environment.NewLine +
        "- 2x Flak Destroyer" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Flak Destroyer" + Environment.NewLine +
        "Flak Destroyers are primarily armed with medium-range anti-air guns with proximity shells, instead of missile launchers. The accuracy of this weapon is low, but a hit can cause large amounts of damage to your aircraft. Keep out of low speeds.";

    private static readonly string LevelGameObjectName = "MISSION_3_SCRIPTS";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission3()
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
            return "Mission accomplished, return to resupply. You'll need it.";
        }
    }

    protected override string DefendFail2Message
    {
        get
        {
            return "...Okay then.";
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
            return 9;
        }
    }

    protected override WeatherPreset Weather
    {
        get
        {
            return WeatherPreset.Stormy;
        }
    }
}