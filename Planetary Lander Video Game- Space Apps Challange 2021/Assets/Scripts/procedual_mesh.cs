using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(MeshFilter))]//make sure this object is in the gameobject
public class procedual_mesh : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    public GameObject meshGameObject;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();

        meshGameObject.GetComponent<MeshFilter>().mesh = mesh;

        createShape();
        updateMesh();
    }

    void createShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)//makes both i and z, i is local to only the for loop now
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 1f; 
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++; //prevent triangle from conecting to start of next row
        }
    }

    /*// Update is called once per frame
    void makeMeshData()
    {
        //create ray of vertices, only renders clockwise side of shape
        vertices = new Vector3[] { new Vector3(0,0,0), new Vector3(0, 0, 1) , new Vector3(1, 0, 0) };
        //create ray of ints
        triangles = new int[] { 0,1,2};
    }
    */

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        MeshCollider meshCollider = meshGameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;

        mesh.RecalculateNormals();//reclaucutes lighting so it looks right
    }

    /*private void OnDrawGizmos()//this makes stuff super laggey
    {
        if (vertices == null)
        {
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }*/

    private void Update()
    {
        updateMesh();
    }
}