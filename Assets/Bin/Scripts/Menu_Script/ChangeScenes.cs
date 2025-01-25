using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] string _destinationScenes;

    #region System
    public void ChangeScene()
    {
        SceneManager.LoadScene(_destinationScenes);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    #endregion
}
