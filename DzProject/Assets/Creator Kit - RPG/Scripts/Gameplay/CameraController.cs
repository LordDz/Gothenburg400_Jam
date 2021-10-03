using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple camera follower class. It saves the offset from the
    ///  focus position when started, and preserves that offset when following the focus.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        public Transform focus;
        public float smoothTime = 2;
        public bool DontMoveY = false;

        Vector3 offset;

        void Awake()
        {
            offset = focus.position - transform.position;
        }

        void Update()
        {
            if (DontMoveY)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(focus.position.x, -2.61f, focus.position.z) - offset, Time.deltaTime * smoothTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, focus.position - offset, Time.deltaTime * smoothTime);
            }
        }
    }
}
