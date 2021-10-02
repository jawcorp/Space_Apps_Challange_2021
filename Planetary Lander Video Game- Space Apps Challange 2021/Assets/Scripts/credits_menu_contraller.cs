using UnityEngine;

public class credits_menu_contraller : MonoBehaviour
{

    public GameObject main_menu;
    public GameObject credits_menu;

    public void goToMainMenu()
    {
        main_menu.SetActive(true);
        credits_menu.SetActive(false);
    }
}
