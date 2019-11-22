using System;
using Assets.Scripts.Levels.Assault;
using Jundroo.SimplePlanes.ModTools;
using Jundroo.SimplePlanes.ModTools.PrefabProxies;

/// <summary>
/// A SimplePlanes custom level.
/// </summary>
public class Mission0_Chaunskaya : AssaultLevelBase
{
    private string _levelGameObjectName;

    private static readonly string Name = "Mission 0b - Naval Strike";
    private static readonly string LevelMap = "Chaunskaya";
    private static readonly string LevelDescription =
        "Qualifier: Naval Strike" + Environment.NewLine +
        "Area: Chaunskaya" + Environment.NewLine +
        "Time: 1700" + Environment.NewLine +
        "Weather: Few Clouds" + Environment.NewLine +
        "Vehicle: Attacker" + Environment.NewLine +
        Environment.NewLine +
        "Objective:" + Environment.NewLine +
        "- Destroy all TGTs within 2 minutes and 30 seconds" + Environment.NewLine +
        Environment.NewLine +
        "Your performance in the previous test mission has been noticed by the top officials. Targets will be firing live rounds during this mission. Completing this mission successfully in time will confirm your team's place in the campaign." + Environment.NewLine +
        Environment.NewLine +
        "TGT(Surface):" + Environment.NewLine +
        "- 1x CIWS Destroyer" + Environment.NewLine +
        "- 2x Destroyer" + Environment.NewLine +
        "- 1x Aircraft Carrier" + Environment.NewLine +
        Environment.NewLine +
        "TIP: CIWS Destroyer" + Environment.NewLine +
        "This destroyer has a laser turret that can shoot down projectiles like missiles. Launch your missiles as late as you can, or attack from the turret's blind spot at the front. Remember that laser turrets stay operational even after the ship is critically damaged.";

    private static readonly string LevelGameObjectName = "TrainingMission_Chaunskaya";

    /// <summary>
    /// Initializes a new instance of the <see cref="Mission1"/> class.
    /// </summary>
    public Mission0_Chaunskaya()
       : base(Name, LevelMap, LevelDescription, LevelGameObjectName)
    {
    }
    
    protected override string StartMessage
    {
        get
        {
            return "You are cleared for takeoff. Bear 260 and engage the targets.";
        }
    }

    protected override string SuccessMessage
    {
        get
        {
            return "We've gotten ourselves a place in the campaign!";
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
            return 17;
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