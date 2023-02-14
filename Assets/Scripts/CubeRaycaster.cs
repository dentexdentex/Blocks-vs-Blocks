using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    public List<GameObject> hitObjects = new List<GameObject>();

    private GameObject root;

    //public bool isMyCube;

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
            hitObjects.Add(hit.collider.gameObject);
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit))
        {
            hitObjects.Add(hit.collider.gameObject);
        }
        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            hitObjects.Add(hit.collider.gameObject);
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            hitObjects.Add(hit.collider.gameObject);
        }
    }

   
}
