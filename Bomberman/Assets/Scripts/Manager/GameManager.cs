using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private PlayerControl player;

    [Header("游戏结束")]
    public bool gameover;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        gameover = player.isDead;
    }
}
