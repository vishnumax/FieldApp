using UnityEngine;
using UnityEngine.UI;

public class HotSpotSelect : MonoBehaviour
{
    Button mbutton;

    [SerializeField] CamDrop cam;

    [Header("Text Settings:")]
    [SerializeField] string title;
    [TextArea(2, 3)]
    [SerializeField] string detail;

    private void OnEnable()
    {
        mbutton = GetComponent<Button>();
        mbutton.onClick.AddListener(() =>
        {
            Actions.HotSpotSelect(cam, title, detail);
        });
    }

    private void OnDisable()
    {
        mbutton.onClick.RemoveAllListeners();
    }
}
