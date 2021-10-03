using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_selector : MonoBehaviour
{

    public Camera first_person_camra;
    public Camera ladder_camera;
    public Camera outside_lander_camera;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
   /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            first_person_camra.enabled = !first_person_camra.enabled;
            ladder_camera.enabled = !ladder_camera.enabled;
        }
    }*/

    public void switch_to_player()
    {
        first_person_camra.enabled = true;
        ladder_camera.enabled = false;
        outside_lander_camera.enabled = false;
    }

    public void switch_to_lander(int camera)
    {
        first_person_camra.enabled = false;

        if (camera == 1)
        {
            ladder_camera.enabled = true;
            outside_lander_camera.enabled = false;
        }

        else if(camera == 2)
        {
            ladder_camera.enabled = false;
            outside_lander_camera.enabled = true;
        }
        else
        {
            Debug.Log("bad input on switch to lander in camera selector");
        }
    }
}
