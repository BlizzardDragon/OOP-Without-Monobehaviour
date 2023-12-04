using System;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    [Serializable]
    public class SceneLoader
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}