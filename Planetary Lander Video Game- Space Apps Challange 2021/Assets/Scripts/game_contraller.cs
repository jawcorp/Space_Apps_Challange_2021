using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_contraller : MonoBehaviour
{
    public GameObject player;

    public GameObject cameraContraller;
    camera_selector cameraSelector;

    public GameObject lander;
    public int lander_start_allitude;

    public lander_contraller landerContraller;

    public player_movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        lander.transform.position = new Vector3(0, lander_start_allitude, 0);

        playerMovement.playerCanMove = true;

        cameraSelector = cameraContraller.GetComponent<camera_selector>();

        cameraSelector.switch_to_lander(2);

        //player.GetComponent<AudioListener>().isActiveAndEnabled();

    }

    // Update is called once per frame
    void Update()
    {
        if (landerContraller.isGrounded)
        {
            if(landerContraller.verticalSpeed <= -10)
            {
                switchToPlayer();
            }
            else if(landerContraller.verticalSpeed > -10)
            {
                switchToPlayer();
            }
        }
    }

    public void switchToPlayer()
    {
        playerMovement.playerCanMove = true;
        player.transform.position = new Vector3(lander.transform.position.x + 20, 5, lander.transform.position.y + 10);
        cameraSelector.switch_to_player();
    }
}
