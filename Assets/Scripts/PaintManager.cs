using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GetComponent<GameManager>();
        List<GameObject> cubes = gameManager.AllyList;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Paint(GameObject gameObject)
    {
        //gameObject.Transform[] allChildren = GetComponentsInChildren<Transform>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("Paint manager");
            }
        }
     }

}

        //foreach (Transform child in allChildren)
        //{
        //    if (child.GetComponent<Renderer>() != null)
        //    {
        //        child.GetComponent<Renderer>().material.color = Color.green;
        //    }
        //}
