namespace Assets.Scripts.Levels.Common.Attack
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using Jundroo.SimplePlanes.ModTools;
   using Jundroo.SimplePlanes.ModTools.PrefabProxies;
    using Jundroo.SimplePlanes.ModTools.AI;
   using SimplePlanesReflection.Assets.Scripts.Levels.Enemies;
    using SimplePlanesReflection.Assets.Scripts.Parts.Modifiers.AircraftAi;
   using UnityEngine;

   /// <summary>
   /// A script that monitors multiple enemies, setting a flag when they are all destroyed.
   /// </summary>
   /// <seealso cref="UnityEngine.MonoBehaviour" />
   public class EnemyDestructionMonitorScript : MonoBehaviour
   {
      /// <summary>
      /// The ground vehicles to monitor.
      /// </summary>
      private List<SimpleGroundVehicleScript> _groundVehicles;

      /// <summary>
      /// The ships that must be defeated in order to complete the level.
      /// </summary>
      [SerializeField]
      private ShipProxy[] _objectiveShips = null;

      /// <summary>
      /// The tanks that must be defeated in order to complete the level.
      /// </summary>
      [SerializeField]
      private AntiAircraftTankProxy[] _objectiveTanks = null;

      /// <summary>
      /// The turrets that must be defeated in order to complete the level.
      /// </summary>
      [SerializeField]
      private RotatingWeaponProxy[] _objectiveTurrets = null;

      [SerializeField]
      private AIAircraftSpawner[] _objectiveAircraft = null;

      /// <summary>
      /// Gets a value indicating whether all objectives have been destroyed.
      /// </summary>
      /// <value>
      /// <c>true</c> if all objectives have been destroyed; otherwise, <c>false</c>.
      /// </value>
      public bool AllObjectivesDestroyed { get; private set; }

      /// <summary>
      /// Gets the total number of objective targets.
      /// </summary>
      /// <value>
      /// The total number of objective targets.
      /// </value>
      public int ObjectivesTotalCount
      {
         get
         {
            return
               this._objectiveShips.Length +
               this._objectiveTanks.Length +
               this._objectiveTurrets.Length +
               this._objectiveAircraft.Length +
               (this._groundVehicles == null ? 0 : this._groundVehicles.Count);
         }
      }

        public int store = 0;

      /// <summary>
      /// Adds a ship objective to monitor.
      /// </summary>
      /// <param name="ship">The ship objective to be added.</param>
      public void AddObjective(ShipProxy ship)
      {
         if (this._objectiveShips == null)
         {
            this._objectiveShips = new ShipProxy[1] { ship };
            return;
         }

         Array.Resize(ref this._objectiveShips, this._objectiveShips.Length + 1);
         this._objectiveShips[this._objectiveShips.Length - 1] = ship;
      }

      /// <summary>
      /// Adds a tank objective to monitor.
      /// </summary>
      /// <param name="tank">The tank objective to be added.</param>
      public void AddObjective(AntiAircraftTankProxy tank)
      {
         if (this._objectiveTanks == null)
         {
            this._objectiveTanks = new AntiAircraftTankProxy[1] { tank };
            return;
         }

         Array.Resize(ref this._objectiveTanks, this._objectiveTanks.Length + 1);
         this._objectiveTanks[this._objectiveTanks.Length - 1] = tank;
      }

      /// <summary>
      /// Adds the ground vehicle objective to monitor.
      /// </summary>
      /// <param name="vehicle">The vehicle objective to be added.</param>
      public void AddObjective(SimpleGroundVehicleScript vehicle)
      {
         if (this._groundVehicles == null)
         {
            this._groundVehicles = new List<SimpleGroundVehicleScript>();
         }

         this._groundVehicles.Add(vehicle);
      }

      /// <summary>
      /// Adds a turret objective to monitor.
      /// </summary>
      /// <param name="turret">The turret objective to be added.</param>
      public void AddObjective(RotatingWeaponProxy turret)
      {
         if (this._objectiveTurrets == null)
         {
            this._objectiveTurrets = new RotatingWeaponProxy[1] { turret };
            return;
         }

         Array.Resize(ref this._objectiveTurrets, this._objectiveTurrets.Length + 1);
         this._objectiveTurrets[this._objectiveTurrets.Length - 1] = turret;
      }

      public void AddObjective(AIAircraftSpawner aircraft)
      {
         if (this._objectiveAircraft == null)
            {
                this._objectiveAircraft = new AIAircraftSpawner[1] { aircraft };
                return;
            }

         Array.Resize(ref this._objectiveAircraft, this._objectiveAircraft.Length + 1);
            this._objectiveAircraft[this._objectiveAircraft.Length - 1] = aircraft;
      }

      /// <summary>
      /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
      /// </summary>
      protected virtual void Start()
      {
         this.StartCoroutine(this.MonitorLevelObjectivesCoroutine());
      }

      /// <summary>
      /// The coroutine that monitors the level objectives.
      /// </summary>
      /// <returns>The enumerator for the coroutine.</returns>
      private IEnumerator MonitorLevelObjectivesCoroutine()
      {
         while (true)
         {
            for (int i = 0; i < 5; i++)
            {
               yield return null;
            }

                int allDestroyed = 0;

            if (this._objectiveTanks != null)
            {
               for (int i = 0; i < this._objectiveTanks.Length; i++)
               {
                  if (this._objectiveTanks[i] != null && this._objectiveTanks[i].IsDead)
                  {
                     allDestroyed++;
                  }
               }
            }

            if (this._objectiveShips != null)
            {
               for (int i = 0; i < this._objectiveShips.Length; i++)
               {
                  if (this._objectiveShips[i] != null && this._objectiveShips[i].IsCriticallyDamaged)
                  {
                     allDestroyed++;
                  }
               }
            }

            if (this._objectiveTurrets != null)
            {
               for (int i = 0; i < this._objectiveTurrets.Length; i++)
               {
                  if (this._objectiveTurrets[i] != null && this._objectiveTurrets[i].IsDisabled)
                  {
                     allDestroyed++;
                  }
               }
            }

            if (this._groundVehicles != null)
            {
               for (int i = 0; i < this._groundVehicles.Count; i++)
               {
                  if (this._groundVehicles[i] != null && this._groundVehicles[i].IsDestroyed)
                  {
                     allDestroyed++;
                  }
               }
            }

            if (this._objectiveAircraft != null)
                {
                    for (int i = 0; i < this._objectiveAircraft.Length; i++)
                    {
                        if (this._objectiveAircraft[i] != null && this._objectiveAircraft[i].AircraftScript.CriticallyDamaged)
                        {
                            allDestroyed++;
                        }
                    }
                }

            if (allDestroyed != store)
                {
                    store = allDestroyed;
                    ServiceProvider.Instance.GameWorld.ShowStatusMessage(allDestroyed + "/" + ObjectivesTotalCount + " targets destroyed", 5);
                }

            if (allDestroyed == ObjectivesTotalCount)
            {
               this.AllObjectivesDestroyed = true;
               ////break;
            }
         }
      }
   }
}