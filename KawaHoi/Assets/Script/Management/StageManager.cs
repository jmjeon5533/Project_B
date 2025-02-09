using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance { get; private set; }
    public Mode modes;
    public bool isGame;

    [Header("게임 관련")]
    [Tooltip("직접적인 게임에 들어갈 맵 오브젝트 프리팹")]
    public MapData Map;
    [Tooltip("생성된 맵 오브젝트")]
    public MapData curMap;
    public Sprite[] structIcons;
    [Header("UI 관련")]
    [Tooltip("준비 단계 UI 활성화/비활성화를 위한 오브젝트 parent")]
    public GameObject setupUIParent;
    public Button gameStartButton;
    [Space(10)]
    public Text gameStartCountText;
    void Awake()
    {
        instance = this;
        modes = new Mode();
        InitMode(modes.prepareMode);
    }
    private void Start()
    {
        curMap = Instantiate(Map,Vector3.zero,Quaternion.identity);
        MapSetting();
        modes.Init();
    }
    private void MapSetting()
    {
        var map = curMap;
        GameObject[][] bases = { map.myBase, map.enemyBase, map.normalBase, map.randomBase };
        for (int i = 0; i < bases.Length; i++)
        {
            for (int j = 0; j < bases[i].Length; j++)
            {
                var s = bases[i][j].AddComponent<Structure>();
                s.icon = structIcons[i];
            }
        }
    }
    void Update()
    {
        modes.Loop();
    }
    public void InitMode(IModeInfo mode)
    {
        modes.curMode = mode;
        modes.Init();
        var isGame = mode == modes.gameMode;
    }
}
