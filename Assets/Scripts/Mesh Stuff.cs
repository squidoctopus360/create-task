using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Mesh mesh;
    private PolygonCollider2D PolyCol;
    private MeshRenderer MeshRend;
    Vector3[] Vertices;
    Vector2[] vec2;
    // Start is called before the first frame update
    void Start()
    {
        PolyCol = GetComponent<PolygonCollider2D>();
        MeshRend = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        Vertices = new Vector3[] 
        {
            new Vector3(1,0,0), 
            new Vector3(1,1,0), 
            new Vector3(0,1,0)
        };

        mesh.vertices = Vertices;

        mesh.triangles = new int[] {2, 1, 0};

        PolyCol.points = ToVector2(Vertices);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2[] ToVector2(Vector3[] vec3)
    {
        vec2 = new Vector2[vec3.Length];
        for (int i = 0; i == vec3.Length; i++)
        {
            vec2[i] = new Vector2(vec3[i].x, vec3[i].y);
        }
        return vec2;
    }
}
