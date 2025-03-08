using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance { get; private set; }
    public Mode modes;
    public bool isGame;

    [Header("���� ����")]
    public float gameTimer;
    public Unit selectUnit;
    [Tooltip("�������� ���ӿ� �� �� ������Ʈ ������")]
    public MapData Map;
    [Tooltip("������ �� ������Ʈ")]
    public MapData curMap;
    public Sprite[] structIcons;
    [Tooltip("���� ������ Unit")]
    [SerializeField]
    private List<Unit> curUnits = new List<Unit>();
    [Header("�غ� �ܰ� UI ����")]
    [Tooltip("�غ� �ܰ� UI Ȱ��ȭ/��Ȱ��ȭ�� ���� ������Ʈ parent")]
    public GameObject setupUIParent;
    public GameObject gameUIParent;
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
        curMap = Instantiate(Map, Vector3.zero, Quaternion.identity);
        MapSetting();
        modes.Init();
    }
    private void MapSetting()
    {
        var map = curMap;
        GameObject[][] bases = { map.myBase, map.normalBase, map.randomBase };
        for (int i = 0; i < bases.Length; i++)
        {
            for (int j = 0; j < bases[i].Length; j++)
            {
                var b = bases[i][j];
                b.layer = LayerMask.NameToLayer("Structure");
                var s = b.AddComponent<Structure>();
                s.icon = structIcons[i];
            }
        }
        for (int i = 0; i < map.enemyBase.Length; i++)
        {
            var b = map.enemyBase[i].summonBase.gameObject;
            b.layer = LayerMask.NameToLayer("Structure");
            var s = b.AddComponent<Structure>();
            s.icon = structIcons[3];
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
    public void AddCurUnit(Unit unit)
    {
        curUnits.Add(unit);
        UIManager.instance.AddUnitPanel(unit);
    }
    public void SummonEnemy(GameObject Obj, Transform target)
    {
        Instantiate(Obj, target.position, Quaternion.identity);
    }
}
