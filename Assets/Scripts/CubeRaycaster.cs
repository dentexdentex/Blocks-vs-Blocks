using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    public List<CubeRaycaster> myNeighborhood = new List<CubeRaycaster>();

    private GameObject root;

    public bool isAlly = false;

    private Renderer rend;

    void Start()
    {
        Invoke("ShootRays", 1f);
       
        
    }

    void Update()
    {
       
    }
    private void ShootRays()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit))
        {
            myNeighborhood.Add(hit.collider.GetComponent<CubeRaycaster>());
            //if (!All.Contains(hit.collider.gameObject))    
            //{
            //All.Add(hit.collider.gameObject);

            //}
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit))
        {
            myNeighborhood.Add(hit.collider.GetComponent<CubeRaycaster>());
            
        }
        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            myNeighborhood.Add(hit.collider.GetComponent<CubeRaycaster>());
           
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            myNeighborhood.Add(hit.collider.GetComponent<CubeRaycaster>());
         
        }
    }

   
}
