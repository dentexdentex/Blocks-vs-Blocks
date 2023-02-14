using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PaintManager paintManager;
    CubeRaycaster cubeRaycaster;


    public List<GameObject> EnemyList = new List<GameObject>();
    public List<GameObject> AllyList = new List<GameObject>();


    private Renderer rend;


    public GameObject gameObject;
    //public bool isMyCube2;
    public bool isMyCube;


    void Start()
    {
        paintManager = FindObjectOfType<PaintManager>();
        cubeRaycaster = FindObjectOfType<CubeRaycaster>();

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("AreaA");

        foreach (GameObject go in objectsWithTag)
        {
            AllyList.Add(go);
        }
        // paintManager.Paint(x);///!! hatalı  listenin 1. elemanı için bunu cagır
        // Debug.Log(AllyList[0]);
        //AllyList[0].GetComponent<PaintManager>().Paint(AllyList[0]); aşagıdaki satırla aynı şey
        paintManager.Paint(AllyList[0]);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
           
            ScreenMouseRay();
        }
    }




    void ScreenMouseRay()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("asd");
            for (int i = 0; i < hit.collider.gameObject.GetComponent<CubeRaycaster>().hitObjects.Count; i++)
            {                                               //tıkladıgımız objenin listesindeki komşu sayısı kadar dönmemizi sağlıyor
                for (int x = 0; x < AllyList.Count; x++)
                {

                    if (hit.collider.gameObject.GetComponent<CubeRaycaster>().hitObjects.Contains(AllyList[x]))
                    {
                        if (!AllyList.Contains(hit.collider.gameObject))
                        {
                            paintManager.Paint(hit.collider.gameObject);
                            AllyList.Add(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
    }

    //void ScreenMouseRay()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        bool canGet = false;

    //        for (int i = 0; i < hit.collider.gameObject.GetComponent<CubeRaycaster>().hitObjects.Count; i++)
    //        {                                               //tıkladıgımız objenin listesindeki komşu sayısı kadar dönmemizi sağlıyor
    //            if (hit.collider.gameObject.GetComponent<CubeRaycaster>().hitObjects[i].GetComponent<CubeRaycaster>().isMyCube)
    //            {
    //                canGet = true;
    //                break;
    //            }
    //        }

    //        if (canGet)
    //        {
    //            hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
    //            hit.collider.gameObject.GetComponent<CubeRaycaster>().isMyCube = true;



    //            int counter = Random.Range(0, 1);
    //            var totalEnemy = GridManager.Instance.EnemyList.Where(x => x.isMyCube2 == true).ToList();
    //            var currentEnemy = Random.Range(0, totalEnemy.Count - 1);//!!!!

    //            if (totalEnemy[currentEnemy].isMyCube2)
    //            {
    //                Debug.Log("koşula girdi");
    //                totalEnemy[currentEnemy].GetComponent<Renderer>().material.color = Color.red;
    //                totalEnemy[currentEnemy].GetComponent<CubeRaycaster>().isMyCube2 = true;
    //            }

    //            // rakip oyuncuyu oynat 



    //        }
    //    }

    //}
}
 