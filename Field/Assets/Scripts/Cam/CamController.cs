using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Cams:")]
    [SerializeField] List<Cam> cams = new List<Cam>();

    private void Start()
    {
        cams.Find(x => x.GetCamDrop == CamDrop.BuildLand).SetDrop(true); ;
    }
}
