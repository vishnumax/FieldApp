using TMPro;
using UnityEngine;

public class DetaillPanel : MonoBehaviour
{
    [SerializeField] TMP_Text mTitle;
    [SerializeField] TMP_Text mDescription;

    [Space]
    [SerializeField] PanelUI mPanel;
    public PanelUI UI => mPanel;

  
    public void Init(string title,string descritption)
    {
        mTitle.text = title;
        mDescription.text = descritption;
    }
}
