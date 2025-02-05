using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [Tooltip("아군 구역")]
    public GameObject[] myBase;
    [Tooltip("적군 구역")]
    public GameObject[] enemyBase;
    [Tooltip("중립 지역")]
    public GameObject[] normalBase;
    [Tooltip("랜덤한 효과가 나오는 지역")]
    public GameObject[] randomBase;
}
