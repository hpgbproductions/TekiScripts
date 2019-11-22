namespace Assets.Scripts.Levels.Assault
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using Common.Attack;
   using Common.Defend;
   using Common.Defend2;
   using CombatArea;
   using DisableChildWeapons;
   using Jundroo.SimplePlanes.ModTools;
   using Jundroo.SimplePlanes.ModTools.PrefabProxies;
   using UnityEngine;

   /// <summary>
   /// A base class for assault type levels.
   /// </summary>
   /// <seealso cref="Jundroo.SimplePlanes.ModTools.Level" />
   public abstract class AssaultLevelBase : Level
   {
      /// <summary>
      /// The name of the root game object for the level so that it can be loaded from the mod.
      /// </summary>
      private string _levelGameObjectName;

      /// <summary>
      /// Initializes a new instance of the <see cref="AssaultLevelBase"/> class.
      /// </summary>
      /// <param name="levelName">The name of the level.</param>
      /// <param name="levelDescription">The level description.</param>
      /// <param name="levelGameObjectName">The name of the root game object for the level so that it can be loaded from the mod.</param>
      public AssaultLevelBase(string levelName, string levelMap, string levelDescription, string levelGameObjectName)
         : base(levelName, levelMap, levelDescription)
      {
         this._levelGameObjectName = levelGameObjectName;
      }

      /// <summary>
      /// Gets the end level dialog message for when the player suffers critical damage.
      /// </summary>
      /// <value>
      /// The end level dialog message for when the player suffers critical damage.
      /// </value>
      protected virtual string CriticalDamageMessage
      {
         get
         {
            return "Your aircraft has been critically damaged. Try again?";
         }
      }

      /// <summary>
      /// Gets the enemy destruction monitor script.
      /// </summary>
      /// <value>
      /// The enemy destruction monitor script.
      /// </value>
      protected EnemyDestructionMonitorScript EnemyMonitor { get; set; }
      protected ProtectionMonitorScript ProtectionMonitor { get; set; }
      protected ProtectionStrictMonitorScript ProtectionMonitor2 { get; set; }
      protected CombatArea CombatArea { get; set; }

      /// <summary>
      /// Gets a value indicating whether or not the level has been initialized.
      /// </summary>
      /// <value>
      /// A value indicating whether or not the level has been initialized.
      /// </value>
      protected bool? Initialized { get; set; }

      /// <summary>
      /// Gets the message displayed to the player when starting the level.
      /// </summary>
      /// <value>
      /// The message displayed to the player when starting the level.
      /// </value>
      protected virtual string StartMessage
      {
         get
         {
            return null;
         }
      }

      /// <summary>
      /// Gets the success message for the end level dialog when the player destroys all targets.
      /// </summary>
      /// <value>
      /// The success message for the end level dialog when the player destroys all targets.
      /// </value>
      protected virtual string SuccessMessage
      {
         get
         {
            return "The targets have been eliminated. Well done!";
         }
      }

      protected virtual string DefendFailMessage
      {
          get
          {
                return "All targets to protect have been destroyed.";
          }
      }

        protected virtual string DefendFail2Message
        {
            get
            {
                return "A critical target to protect has been destroyed.";
            }
        }

      protected virtual string OutOfTimeMessage
        {
            get
            {
                return null;
            }
        }

      protected override float TimerCountdown
        {
            get
            {
                return 0;
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
                return true;
            }
        }

        protected virtual int TimeOfDay
        {
            get
            {
                return 12;
            }
        }

      protected virtual WeatherPreset Weather
        {
            get
            {
                return WeatherPreset.Clear;
            }
        }

        protected override string FormatScore(float score)
        {
            return score < 0 ? string.Format("{0}",score) : string.Format("{0}/{1} destroyed", score, EnemyMonitor.ObjectivesTotalCount);
        }

        /// <summary>
        /// Attempts to initialize the level.
        /// </summary>
        protected virtual void Initialize()
      {
         // Only try to initialize if we have not already failed.
         if (!this.Initialized.HasValue)
         {
            try
            {
               var obj = ServiceProvider.Instance.ResourceLoader.LoadGameObject(this._levelGameObjectName);
               if (obj == null)
               {
                  Debug.LogErrorFormat("Unable to instantiate game object: {0}", this._levelGameObjectName);
                  this.Initialized = false;
                  return;
               }

               this.EnemyMonitor = obj.GetComponent<EnemyDestructionMonitorScript>();
               if (this.EnemyMonitor == null)
               {
                  Debug.LogErrorFormat("Unable to get the enemy destruction monitor script from the level game object '{0}'", this._levelGameObjectName);
                  this.Initialized = false;
                  return;
               }

               this.ProtectionMonitor = obj.GetComponent<ProtectionMonitorScript>();
               if (this.ProtectionMonitor == null)
               {
                  Debug.LogErrorFormat("Unable to get the defend destruction monitor script from the level game object '{0}'", this._levelGameObjectName);
                  this.Initialized = false;
                  return;
               }

               this.ProtectionMonitor2 = obj.GetComponent<ProtectionStrictMonitorScript>();
               if (this.ProtectionMonitor2 == null)
               {
                   Debug.LogErrorFormat("Unable to get the strict defend destruction monitor script from the level game object '{0}'", this._levelGameObjectName);
                   this.Initialized = false;
                   return;
               }

               this.CombatArea = obj.GetComponent<CombatArea>();
               if (this.CombatArea == null)
               {
                        Debug.LogErrorFormat("Unable to get the combat area monitor script from the level game object '{0}'", this._levelGameObjectName);
                        this.Initialized = false;
                        return;
               }

                    ServiceProvider.Instance.EnvironmentManager.UpdateTimeOfDay(TimeOfDay, 0, false, true);
                    ServiceProvider.Instance.EnvironmentManager.UpdateWeather(Weather, 0, true);

                    if (!string.IsNullOrEmpty(this.StartMessage))
               {
                  ServiceProvider.Instance.GameWorld.ShowStatusMessage(this.StartMessage);
               }

               this.Initialized = true;
            }
            catch (Exception ex)
            {
               Debug.LogException(ex);
               this.Initialized = false;
            }
         }
      }

      /// <summary>
      /// Update is called every frame.
      /// </summary>
      protected override void Update()
      {
         base.Update();

         // Initialize the level if not yet initialized.
         // If initialization failed, skip the update.
         if (!(this.Initialized ?? false))
         {
            this.Initialize();
            return;
         }

         // Check for win/lose conditions and end the level if needed.
         if (this.EnemyMonitor.AllObjectivesDestroyed)
         {
             this.EndLevel(true, this.SuccessMessage, EnemyMonitor.store);
             this.PauseTimer(true);
         }
         else if (this.ProtectionMonitor.AllProtectionDestroyed)
         {
                this.EndLevel(false, this.DefendFailMessage, -100);
         }
         else if (this.ProtectionMonitor2.AnyProtectionDestroyed)
         {
             this.EndLevel(false, this.DefendFail2Message, -1000);
         }

         else if (ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
         {
             this.EndLevel(false, this.CriticalDamageMessage, EnemyMonitor.store);
         }

         else if (TimerCountdown > 0 && TimerEnabled == true)
            {
                if (ElapsedTime >= TimerCountdown)
                {
                    this.EndLevel(false, this.OutOfTimeMessage, EnemyMonitor.store);
                }
            }
      }
   }
}