using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obstacleSpeed = 0;
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.right * Time.deltaTime * GameManager.instance.gameSpeed);

            if (transform.position.x < -10)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
