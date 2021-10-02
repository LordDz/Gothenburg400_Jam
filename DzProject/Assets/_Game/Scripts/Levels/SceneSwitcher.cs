using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts.Levels
{
    public class SceneSwitcher : MonoBehaviour
    {
        public string SceneToSwitchTo;

        public void SwitchToNextScene()
        {
            SceneManager.LoadScene(SceneToSwitchTo);
        }
    }
}
