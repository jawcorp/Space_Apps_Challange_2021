using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_contraller : MonoBehaviour
{

    public GameObject main_menu;
    public GameObject options_menu;
    public GameObject credits_menu;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void goToOptionsMenu()
    {
        options_menu.SetActive(true);
        main_menu.SetActive(false);
    }

    public void goToCreditsMenu()
    {
        credits_menu.SetActive(true);
        main_menu.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
