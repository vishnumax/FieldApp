using Unity.Cinemachine;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] CinemachineClearShot m_Shot;

    [Space]
    [SerializeField] CamDrop camDrop;
    public CamDrop GetCamDrop => camDrop;

    private void Awake()
    {
        m_Shot = GetComponent<CinemachineClearShot>();
    }


    public void SetDrop(bool enable)
    {
        m_Shot.Priority = enable? 20 : 10;
    }
}


public enum CamDrop
{
    BuildTop,
    BuildLand,
    Cradle,
    Robot,
    BMU
}