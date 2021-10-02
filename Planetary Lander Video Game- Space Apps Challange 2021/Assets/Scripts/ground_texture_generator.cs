using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_texture_generator : MonoBehaviour
{
    public int width = 250;
    public int height = 250;

    public float scale = 20;

    public GameObject ground_mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = ground_mesh.GetComponent<Renderer>();
        renderer.material.mainTexture = generateTexture();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Texture2D generateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = calculateColor(x,y);

                texture.SetPixel(x, y, color);
            }
        }


        texture.Apply();
        return texture;

    }

    Color calculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / width * scale; 

        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        return new Color(sample, sample, sample); ;
    }
}
