using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fade_in_out_gradient : MonoBehaviour
{
    public GameObject panel;
    public float fade_change_rate;
    private float i;
    private bool fade_in = true;

    // Start is called before the first frame update
    void Start()
    {
        panel.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        i = 255;
    }

    private void Update()
    {
        if (fade_in)
        {
            i = i - fade_change_rate *  Time.deltaTime;

            if (i < 0)
            {
                fade_in = false;
            }
            else
            {
                panel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)i);
            }

        }
        else
        {
            i = i + fade_change_rate * Time.deltaTime;

            if (i > 255)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                panel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)i);
            }
        }
    }
}
