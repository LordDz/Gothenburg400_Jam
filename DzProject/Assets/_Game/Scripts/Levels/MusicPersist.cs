using UnityEngine;

namespace Assets._Game.Scripts.Levels
{
    public class MusicPersist : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
