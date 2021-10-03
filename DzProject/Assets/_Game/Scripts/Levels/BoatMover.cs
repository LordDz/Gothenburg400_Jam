using System.Collections;
using UnityEngine;

namespace Assets._Game.Scripts.Levels
{
    public class BoatMover : MonoBehaviour
    {

        // Use this for initialization
        private float timeWait = 0;
        public float timeDone = 10f;

        public Vector3 Speed;
        public GameObject ObjEnableWhenDone;

        private bool isDone = false;


        // Update is called once per frame
        void Update()
        {
            timeWait += Time.deltaTime;

            if (!isDone && timeWait > timeDone)
            {
                isDone = true;
                if (ObjEnableWhenDone)
                {
                    ObjEnableWhenDone.SetActive(true);
                }
                enabled = false;
            }
            else
            {
                transform.position += Speed * Time.deltaTime;
            }
        }
    }
}
