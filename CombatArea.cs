namespace Assets.Scripts.CombatArea
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Jundroo.SimplePlanes.ModTools;
    using SimplePlanesReflection.Assets.Scripts.Parts.Targeting;
    using UnityEngine;

    public class CombatArea : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _combatCenter = new Vector3(0,0,0);

        [SerializeField]
        private int _combatRadius = 20000;

        [SerializeField]
        private int _warningRadius = 15000;

        [SerializeField]
        private float _allowTime = 20;

        [SerializeField]
        private float TimeRemaining = 20;

        private string _combatArea;

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_combatCenter, _combatRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_combatCenter, _warningRadius);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
            {

            float distance = (_combatCenter - ServiceProvider.Instance.GameWorld.FloatingOriginOffset - ServiceProvider.Instance.PlayerAircraft.MainCockpitPosition).magnitude;

            if (distance > _warningRadius && distance < _combatRadius && !ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
            {
                ServiceProvider.Instance.GameWorld.ShowStatusMessage("Return to the battlefield!", 1);
            }

            if (distance > _combatRadius && !ServiceProvider.Instance.PlayerAircraft.CriticallyDamaged)
                {
                    TimeRemaining = TimeRemaining - Time.deltaTime;
                    ServiceProvider.Instance.GameWorld.ShowStatusMessage(string.Format("Return to the battlefield! ({0:N1})",TimeRemaining),1);

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