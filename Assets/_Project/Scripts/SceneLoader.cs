using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireAndWater
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}