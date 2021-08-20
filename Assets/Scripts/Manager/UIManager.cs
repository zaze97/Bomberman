using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject HealthBar;
    public Toggle PauseButton;
    [Header("菜单")]
    public GameObject PauseMenu;
    public Button ResumeButton;
    public Button PlayAgainButton;
    public Button QuitButton;

    public Slider bossHealthBar;
    /// TODD 血条未完成
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
    }
    private void Start()
    {
        PauseButton.onValueChanged.AddListener((a)=> { SetPauseMenu(a); });
    }

    private void SetPauseMenu(bool value)
    {
        PauseMenu.SetActive(value);

        if(value)
        Time.timeScale = 0;
        else
        Time.timeScale = 1;
    }

    public void UpdateHealth(float currentHealth)
    {
        switch (currentHealth)
        {
            case 3:
                HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                HealthBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                HealthBar.transform.GetChild(0).gameObject.SetActive(false);
                HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                HealthBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 1:
                HealthBar.transform.GetChild(0).gameObject.SetActive(false);
                HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                HealthBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 0:
                HealthBar.transform.GetChild(0).gameObject.SetActive(false);
                HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 血条更新
    /// </summary>
    /// <param name="health"></param>
    public void SetBossHealth(float health)
    {
        bossHealthBar.maxValue = health;
    }
    public void UpdateBossHealth(float health)
    {
        bossHealthBar.value = health;
    }
}
