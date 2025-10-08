using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Cams:")]
    [SerializeField] List<Cam> cams = new List<Cam>();


    [Space]
    [SerializeField] LookCam freeLookCam;

    private void Start()
    {
        cams.Find(x => x.GetCamDrop == CamDrop.BuildLand).SetDrop(true); ;
    }

    public void SetFreeLookCam()
    {
        foreach (var item in cams)
        {
            item.SetDrop(false);
        }

        freeLookCam.SetDrop(true);
    }
}
