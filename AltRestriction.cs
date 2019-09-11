namespace Assets.Scripts.CombatArea
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Jundroo.SimplePlanes.ModTools;
    using SimplePlanesReflection.Assets.Scripts.Parts.Targeting;
    using UnityEngine;

    public class AltRestriction : MonoBehaviour
    {
        [SerializeField]
        private int _combatAlt = 4000;

        [SerializeField]
        private int _warningAlt = 3000;

        [SerializeField]
        private float _allowTime = 5;

        [SerializeField]
        private float TimeRemaining = 5;

        private string _combatArea;

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = new Color32(255, 0, 0, 64);
            Gizmos.DrawCube(new Vector3(0, _combatAlt, 0), new Vector3(200000, 1, 200000));
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
            {

            float altitude = ServiceProvider.Instance.PlayerAircraft.Altitude;

            if (altitude > _warningAlt)
            {
                ServiceProvider.Instance.GameWorld.ShowStatusMessage(string.Format("Reduce altitude! ({0:N0}/{1})", altitude, _combatAlt), 1);
            }

            if (altitude > _combatAlt && !ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
                {
                    TimeRemaining = TimeRemaining - Time.deltaTime;
                    ServiceProvider.Instance.GameWorld.ShowStatusMessage(string.Format("Reduce altitude! ({0:N0}/{1}) ({2:N1})", altitude, _combatAlt, TimeRemaining),1);

                    if (TimeRemaining < 0)
                    {
                        ServiceProvider.Instance.GameWorld.CreateExplosion(ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition, 100);
                    }
            }

            else
                {
                    TimeRemaining = _allowTime;
                }
            }
        }

    }