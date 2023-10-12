using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageObstacle
{
    public List<GameObject> obstacle = new List<GameObject>();
}
public class RespawnManager : MonoBehaviour
{
    public List<StageObstacle> ObstaclePool = new List<StageObstacle>();
    public int objCnt = 1;
    GameManager gm;
    void Awake()
    {
        gm = GameManager.instance;
        if (gm == null)
        {
            Debug.LogError("GameManager instance is not set.");
            return;
        }
        for (int i =0; i < gm.stages.Length;i++)
        {
            StageObstacle stage = new StageObstacle();
            for (int x = 0; x < gm.stages[i].obstacle.Length; x++)
            {
                for (int q = 0; q < objCnt; q++)
                {
                    stage.obstacle.Add(CreateObj(gm.stages[i].obstacle[x], transform));
                }
            }
            ObstaclePool.Add(stage);
        }
    }

    private void Start()
    {
        GameManager.instance.onPlay += PlayGame;
    }

    void PlayGame(bool isplay)
    {
        if (isplay)
        {
            for(int i=0;i<ObstaclePool.Count; i++)
            {
                for (int x = 0; x < ObstaclePool[i].obstacle.Count; x++)
                {
                    if (ObstaclePool[i].obstacle[x].activeSelf)
                        ObstaclePool[i].obstacle[x].SetActive(false);
                }
            }
            StartCoroutine(CreateObstacle());
        }
        else
            StopAllCoroutines();
    }

    IEnumerator CreateObstacle()
    {
        yield return new WaitForSeconds(0.5f);
        while(gm.isPlay)
        {
            ObstaclePool[gm.curStage].obstacle[DeactiveObstacle(ObstaclePool[gm.curStage].obstacle)].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
    
    int DeactiveObstacle(List<GameObject>obstacle)
    {
        List<int> num = new List<int>();
        for(int i=0; i<obstacle.Count; i++)
        {
            if (!obstacle[i].activeSelf)
                num.Add(i);
        }
        int x = 0;
        if (num.Count > 0)
            x = num[Random.Range(0, num.Count)];
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
