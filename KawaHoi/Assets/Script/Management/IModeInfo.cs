using System.Collections;
using UnityEngine;

public interface IModeInfo
{
    public void Init();
    public void Loop();
}
public class GameMode : IModeInfo
{
    public void Init()
    {
        var s = StageManager.instance;
        s.setupUIParent.SetActive(false);
        s.gameUIParent.SetActive(true);
        s.StartCoroutine(ReadyGameCountDown());
    }
    public void Loop()
    {

    }
    IEnumerator ReadyGameCountDown()
    {
        var s = StageManager.instance;
        for (int i = 3; i > 0; i--)
        {
            s.gameStartCountText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        s.gameStartCountText.text = "";
        StageManager.instance.isGame = true;
    }
}
public class PrepareMode : IModeInfo
{
    public void Init()
    {
        var s = StageManager.instance;
        s.isGame = false;
        s.gameStartButton.onClick.RemoveAllListeners();
        s.gameStartButton.onClick.AddListener(() =>
        {
            s.InitMode(s.modes.gameMode);
        });
        s.setupUIParent.SetActive(true);
        s.gameUIParent.SetActive(false);
    }
    public void Loop()
    {

    }
}
public class Mode
{
    public readonly IModeInfo gameMode;
    public readonly IModeInfo prepareMode;
    public Mode()
    {
        gameMode = new GameMode();
        prepareMode = new PrepareMode();
    }
    public IModeInfo curMode;
    public void Init() => curMode.Init();
    public void Loop() => curMode.Loop();
}
