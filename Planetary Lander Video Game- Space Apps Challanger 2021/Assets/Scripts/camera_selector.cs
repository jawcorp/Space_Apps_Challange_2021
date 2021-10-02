using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_selector : MonoBehaviour
{

    public Camera first_person_camra;
    public Camera second_camera;

    // Start is called before the first frame update
    void Start()
    {
        first_person_camra.enabled = true;
        second_camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            first_person_camra.enabled = !first_person_camra.enabled;
            second_camera.enabled = !second_camera.enabled;
        }
    }
}
