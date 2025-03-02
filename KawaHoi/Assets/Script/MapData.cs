using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [Tooltip("�Ʊ� ����")]
    public GameObject[] myBase;
    [Tooltip("���� ����")]
    public SummonEnemyData[] enemyBase;
    [Tooltip("�߸� ����")]
    public GameObject[] normalBase;
    [Tooltip("������ ȿ���� ������ ����")]
    public GameObject[] randomBase;
}
[System.Serializable]
public class SummonEnemyData
{
    public Transform summonBase;
    public GameObject summonPrefab;
    public float summonTime;
}
