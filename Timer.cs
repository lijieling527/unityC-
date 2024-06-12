using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // 引用 TextMeshPro

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // 用于显示计时的 UI 组件
    public string nextSceneName; // 下一场景的名称

    private float startTime;
    private bool isTiming;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTiming)
        {
            UpdateTimer();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
        float totalTime = Time.time - startTime;
        MedalManager.TotalTime = totalTime; // 存储时间数据
        MedalManager.GamePlayed = true; // 标记游戏已经进行过
        SceneManager.LoadScene("menu"); // 切换到下一场景
    }

    private void UpdateTimer()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00.00");
        timerText.text = minutes + ":" + seconds;
    }
}
