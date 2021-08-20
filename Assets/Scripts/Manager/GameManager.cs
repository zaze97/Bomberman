using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private PlayerControl player;


    private List<Enemy> Enemies = new List<Enemy> { };

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
        if(player!=null)
        gameover = player.isDead;

        //TODD
        //显示游戏结束面板，观察者模式
        //UIManager.instance.GameOverUI(gameover);
    }
    /// <summary>
    /// 观察者模式，让别人通知自己
    /// </summary>
    /// <param name="control"></param>
    public void IsPlayer(PlayerControl control)
    {
        player = control;
    }

    /// <summary>
    /// 增加敌人
    /// </summary>
    /// <param name="enemy"></param>
    public void IsEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    /// <summary>
    /// 移除敌人
    /// </summary>
    /// <param name="enemy"></param>
    public void DesEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);

        if (Enemies.Count == 0)
        {
            //开门动画
            //通往下一关

            SaveDate();
        }
    }

    //TODD
    //删除键值，从新添加
    //PlayerPrefs.DeleteKey("playerHealth");


    /// <summary>
    /// 读取生命数据
    /// </summary>
    /// <returns></returns>
    public float LoadHealth()
    {
        if (!PlayerPrefs.HasKey("playerHealth"))
        {
            PlayerPrefs.SetFloat("playerHealth", 3f);

        }

        float currentHealth = PlayerPrefs.GetFloat("playerHealth");
        return currentHealth;
    }
    /// <summary>
    /// 存储生命数据
    /// </summary>
    public void SaveDate()
    {
        PlayerPrefs.SetFloat("playerHealth", player.health);
        //TODD 保存下一个加载的场景
        //PlayerPrefs.SetInt("sceneIndex",)
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 新游戏
    /// </summary>
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();//清除全部数据
        //TODD加载场景
    }
    /// <summary>
    /// 加载游戏
    /// </summary>
    public void ContinueGame()
    {
        if (!PlayerPrefs.HasKey("sceneIndex"))
        {
            //加载保存的数据所指向的场景
            //场景管理器
        }
        else
        {

        }
    }
}