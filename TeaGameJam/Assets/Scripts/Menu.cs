
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AboutMenu;

    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnAboutButton()
    {
        MainMenu.SetActive(false);
        AboutMenu.SetActive(true);
    }

    public void OnBackButton()
    {
        MainMenu.SetActive(true);
        AboutMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
