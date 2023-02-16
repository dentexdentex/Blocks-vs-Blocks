using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PaintManager paintManager;
    CubeRaycaster cubeRaycaster;

    [SerializeField] private Compliting compliting;

    public List<CubeRaycaster> EnemyList = new List<CubeRaycaster>();
    public List<CubeRaycaster> AllyList = new List<CubeRaycaster>();



    private Renderer rend;


    //public bool isMyCube2;
    public bool isMyCube;


    void Start()
    {
        paintManager = FindObjectOfType<PaintManager>();
        cubeRaycaster = FindObjectOfType<CubeRaycaster>();

        GameObject firstAlly = GameObject.FindGameObjectWithTag("AreaA");
        GameObject firstEnemy = GameObject.FindGameObjectWithTag("AreaF");

        var enemy = firstEnemy.GetComponent<CubeRaycaster>();
        var ally = firstAlly.GetComponent<CubeRaycaster>();
        enemy.isAlly = true;
        ally.isAlly = true;
        AllyList.Add(ally);
        EnemyList.Add(enemy);
        // paintManager.Paint(x);///!! hatalı  listenin 1. elemanı için bunu cagır
        // Debug.Log(AllyList[0]);
        //AllyList[0].GetComponent<PaintManager>().Paint(AllyList[0]); aşagıdaki satırla aynı şey
        paintManager.Paint(AllyList[0].gameObject);
        paintManager.Paint2(EnemyList[0].gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScreenMouseRay();
            isFinish();
        }
    }
    void isFinish()
    {
        if (AllyList.Count + EnemyList.Count == 6)
        {
            Time.timeScale = 0;
            Debug.Log("fin,sh");
        }
    }
    void ScreenMouseRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < hit.collider.gameObject.GetComponent<CubeRaycaster>().myNeighborhood.Count; i++)
            {                                               //tıkladıgımız objenin listesindeki komşu sayısı kadar dönmemizi sağlıyor
                for (int x = 0; x < AllyList.Count; x++)
                {
                    if (hit.collider.gameObject.GetComponent<CubeRaycaster>().myNeighborhood.Contains(AllyList[x]))     //tıklanılan alan alylistenin komsusu ise yapabilsin
                    {
                        if (!AllyList.Contains(hit.collider.GetComponent<CubeRaycaster>()))    //daha önce alanı ele geçirmemişsek orayı boya ve dost alanına ekle
                        {
                            paintManager.Paint(hit.collider.gameObject);
                            AllyList.Add(hit.collider.GetComponent<CubeRaycaster>());
                            hit.collider.GetComponent<CubeRaycaster>().isAlly = true;
                        }
                    }
                }
            }
        }
            
        EnemyTurn();

        // 1. secenek rastgele seçilen yerin komsularına bakıp  komsusu kırmızı ise seçebilmeliyiz
        //2. secenek enemy listemisizn komsularından birini seçtik ve oradan ilerlemeye devam ettik

        //int randomInterval;
        //randomInterval = Random.Range(0,EnemyList.Count);
        //paintManager.Paint2(EnemyList[randomInterval]);
    }

    private void EnemyTurn()
    {
        //if (EnemyList.Last().myNeighborhood.Count == 0) return;
        var totalMoveableNeighborhood = EnemyList.LastOrDefault()?.myNeighborhood.Where(x => x.isAlly == false)?.ToList();
        if (totalMoveableNeighborhood is null)
        {
            Debug.Log("List is null");
            compliting.ChangeColor();
            return;
        }
        if (totalMoveableNeighborhood.Count == 0)
        {
            Debug.Log("Count = 0");

            if (EnemyList.Count != 0)
            {
                EnemyList.Remove(EnemyList.Last());
                //if (EnemyList.Count != 0)
                //{
                //    var newTotalMoveableNeighborhoodList = EnemyList.Last().myNeighborhood.Where(x => x.isAlly == false).ToList();
                //    ChooseAvailableEnemy(newTotalMoveableNeighborhoodList);
                //}
                Debug.Log("Remove Last Enemy");
                EnemyTurn();
            }
            else
            {
                Debug.Log("Didnt Remove Last Enemy");
            }
                //compliting.ChangeColor();
        }
        else
        {
            Debug.Log(totalMoveableNeighborhood.Count);
            Debug.Log("Elsese");
            ChooseAvailableEnemy(totalMoveableNeighborhood);
        }   
    }

    private void ChooseAvailableEnemy(List<CubeRaycaster> _enemyList )
    {
        var totalNeighborhoodCount = _enemyList.Count - 1;
        var rnd = Random.Range(0, totalNeighborhoodCount);
        if (_enemyList.Count == 0) return;
        if (!EnemyList.Contains(_enemyList[rnd]))
        {
            _enemyList[rnd].isAlly = true;
            EnemyList.Add(_enemyList[rnd]);
            paintManager.Paint2(_enemyList[rnd].gameObject);
        }
    }


}
 