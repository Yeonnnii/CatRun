using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Stage
{
    public Sprite[] grounds;
    public GameObject[] obstacle;
}
public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    public float gameSpeed=1;
    public bool isPlay = false;
    public GameObject playBtn;

    public TextMeshProUGUI bestScoreTxt;
    public TextMeshProUGUI scoreTxt;
    public int score = 0;

    public int curStage;
    public int[] stageScore;
    public Stage[] stages;

    private void Start()
    {
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    IEnumerator AddScore()
    {
        while(isPlay)
        {
            try
            {
                if (stageScore[curStage] <= score)
                {
                    curStage++;
                }
            }
            catch { }
            score++;
            scoreTxt.text = score.ToString();
            gameSpeed = gameSpeed + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void PlayBtn()
    {
        playBtn.SetActive(false);
        isPlay = true;
        curStage = 0;
        score = 0;
        onPlay.Invoke(isPlay);
        scoreTxt.text = score.ToString();
        StartCoroutine(AddScore());
    }

    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());
        if (PlayerPrefs.GetInt("BestScore", 0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScoreTxt.text = score.ToString();
        }
    }
}
