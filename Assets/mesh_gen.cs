// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequirementComponent(typeof(MeshFilter))]
// public class mesh_gen : MonoBehaviour
// {
//     Mesh mesh;
//     Vector3[] v;
//     int[] t;

//     void Start()
//     {
//         mesh= new Mesh();
//         GetComponent<MeshFilter>().mesh=mesh;
//         Shape();
//         UpdateMesh();
//     }

//     void Shape( ){
//         vertices= new Vector3[]{
//             new Vector3 (0,0,0);
//             new Vector3 (0,0,1);
//             new Vector3 (1,0,0);
//         };

//         triangles= new int[]{
//             0,1,2
//         };
//     }

//     void UpdateMesh(){
//         mesh.Clear();
//         mesh.v = vertices;
//         mesh.t = triangles;
//     }
    
    
// }
