using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compliting : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	public List<GameObject> gameObjectList;

	public GameObject gameObj1;
	public GameObject gameObj2;
	public GameObject gameObj3;
	public GameObject gameObj4;
	public GameObject gameObj5;
	public GameObject gameObj6;

	void Start()
	{
		gameObjectList = new List<GameObject>();

		gameObjectList.Add(gameObj1);
		gameObjectList.Add(gameObj2);
		gameObjectList.Add(gameObj3);
		gameObjectList.Add(gameObj4);
		gameObjectList.Add(gameObj5);
		gameObjectList.Add(gameObj6);
	}
	public void ChangeColor()
	{
        if (gameManager.EnemyList.Count == 0)
        {
            //  gameObjectList  içindekiler beyaz olanlrı yeşil yap
            for (int i = 0; i < 6; i++)
            {
				for (int j = 0; j < gameObjectList[i].transform.childCount; j++)
				{
                    if (gameObjectList[i].transform.GetChild(j).GetComponent<MeshRenderer>().material.color != Color.green && gameObjectList[i].transform.GetChild(j).GetComponent<MeshRenderer>().material.color != Color.red)
                    {
                        Debug.Log("ASDASD");
                        // gameObjectList[i].GetComponent<MeshRenderer>().material.color = Color.green;
                        gameObjectList[i].transform.GetChild(j).GetComponent<Renderer>().material.color = Color.green;
                    }
                }
                
            }
        }
    }
}			
