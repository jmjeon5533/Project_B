using UnityEngine;

public class CamManager : MonoBehaviour
{
    public enum CamState
    {
        normal,
        top
    }
    private Camera cam;
    public CamPosData[] camPosDatas;
    private CamState curCamState;
    private void Start()
    {
        cam = Camera.main;
    }
    public void NextCamState()
    {
        curCamState++;
        if ((int)curCamState >= 2) curCamState = 0;
        cam.transform.position = camPosDatas[(int)curCamState].pos;
        cam.transform.eulerAngles = camPosDatas[(int)curCamState].rot;
    }

}
[System.Serializable]
public class CamPosData
{
    public Vector3 pos;
    public Vector3 rot;
}
