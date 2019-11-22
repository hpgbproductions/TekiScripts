using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission5 : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 5 - Taymyrsky";
    private static readonly string LevelMap = "Taymyr";
    private static readonly string LevelDescription =
        "Mission 5" + Environment.NewLine +
        "Area: Taymyr Peninsula" + Environment.NewLine +
        "Time: 1600" + Environment.NewLine +
        "Weather: Overcast" + Environment.NewLine +
        "Vehicle: Multirole" + Environment.NewLine +
        Environment.NewLine +
        "Objectives:" + Environment.NewLine +
        "- Destroy all TGTs" + Environment.NewLine +
        "- Do not fly above 1,200 m (4,000 ft)" + Environment.NewLine +
        Environment.NewLine +
        "Captured intelligence from the previous mission shows the location of hidden missile launch facilities in the headland. Destroy all the cruise missile launch sites. You are not to fly above 4,000 ft as you be targeted by long range SAMs above that altitude." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 3x Cruise Missile" + Environment.NewLine +
        "- 2x Concealed Launch Site" + Environment.NewLine +
        "- 1x Satellite Dish" + Environment.NewLine +
        Environment.NewLine +
        "TIP: Concealed Launch Site" + Environment.NewLine +
        "Some launch sites are underground under a very thick layer of concrete. Heavy explosives are needed to destroy the facilities - standard missiles may be ineffective.";

    private static readonly string LevelGameObjectName = "MISSION_5_SCRIPTS";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission5()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "Destroy enemy base facilities. Careful, enemy fighters appeared on radar.";
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
            return "";
        }
    }

    protected override string DefendFail2Message
    {
        get
        {
            return "Hey, don't touch that!";
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
            return "They are launching the missiles!";
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
            return 16;
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