using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public float speed;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        temp = tiles[0];
    }
    SpriteRenderer temp;


    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay)
        {
            for(int i=0;i<tiles.Length; i++)
            {
                if(-15>=tiles[i].transform.position.x)
                {
                    for(int q=0;q<tiles.Length;q++)
                    {
                        if (temp.transform.position.x < tiles[q].transform.position.x)
                            temp = tiles[q];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 3.2f, -5f);
                    tiles[i].sprite = gm.stages[gm.curStage].grounds[Random.Range(0,gm.stages[gm.curStage].grounds.Length)];
                }
            }
            for(int i=0;i<tiles.Length;i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * gm.gameSpeed);
            }
        }
    }
}
