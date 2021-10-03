using System.Collections;
using UnityEngine;

namespace Assets._Game.Scripts.Levels
{
    public class SceneSwitchOnWake : MonoBehaviour
    {
        public SceneSwitcher sceneSwitcher;
        //void Awake()
        //{
        //    sceneSwitcher.SwitchToNextScene();
        //}

        void OnEnable()
        {
            sceneSwitcher.SwitchToNextScene();
        }
    }
}
