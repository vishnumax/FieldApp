using UnityEngine;
using UnityEngine.UI;
public class AppController : MonoBehaviour
{
    [SerializeField] PanelUI mMainMenu;


    [Space]
    [SerializeField] Button mShowButton;

    [Header("Fade Screen")]
    [SerializeField] FadeUI mFadeUI;

    [Header("CamController")]
    [SerializeField] CamController mCamController;

    private void Start()
    {
        mMainMenu.Enable(true);
    }

    private void OnEnable()
    {
        mShowButton.onClick.AddListener(() =>
        {
            mMainMenu.Enable(false);
            StartCoroutine(mFadeUI.FadeOutIn());
            mCamController.SetFreeLookCam();
        });
    }

    private void OnDisable()
    {
        mShowButton.onClick.RemoveAllListeners();
    }
}
