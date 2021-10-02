using UnityEngine;

public class options_menu_contraller : MonoBehaviour
{

    public GameObject main_menu;
    public GameObject options_menu;

    public void goToMainMenu()
    {
        main_menu.SetActive(true);
        options_menu.SetActive(false);
    }
}
