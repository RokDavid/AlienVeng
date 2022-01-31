using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float refreshrate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {   
        while(gameObject.activeSelf)
        {
            // bake all vertices of the mesh to m
            Mesh m = new Mesh();
            skinnedMesh.BakeMesh(m);
            // assing baked vertices to mesh m2
            Vector3[] vertices = m.vertices;
            Mesh m2 = new Mesh();
            m2.vertices = vertices;
            // set properly mesh vertices to vfxGraph
            VFXGraph.SetMesh("Mesh", m2);

            yield return new WaitForSeconds(refreshrate);
        }
    }

}
