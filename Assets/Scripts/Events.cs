using UnityEngine.SceneManagement;
using UnityEngine;
using System.Diagnostics;

public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        SceneManager.LoadScene("test"); 
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");  
    }
}
