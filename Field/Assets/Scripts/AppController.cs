using System;
using UnityEngine;
using UnityEngine.UI;
public class AppController : MonoBehaviour
{
    [SerializeField] PanelUI mMainMenu;
    [SerializeField] PanelUI mPanelCradle;
    [SerializeField] DetaillPanel mDetaillPanel;

    [Space]
    [SerializeField] Button mShowButton;
    [SerializeField] Button mBackButton;
    [SerializeField] Button mPlayButton;
    [Space]
    [SerializeField] GameObject mHotspots;

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

            mPanelCradle.Enable(true);

            mHotspots.SetActive(true);
        });

        mBackButton.onClick.AddListener(() => 
        {
            mHotspots.SetActive(true);
            mBackButton.gameObject.SetActive(false);

            mCamController.SetFreeLookCam();

            mDetaillPanel.UI.Enable(false);
            mPanelCradle.Enable(true);
        });

        mPlayButton.onClick.AddListener(() => AppData.mCurrentAni.Play("Cleaning"));

        Actions.HotSpotSelect += HotSpotSelectAct;
    }

    private void OnDisable()
    {
        mShowButton.onClick.RemoveAllListeners();
        mBackButton.onClick.RemoveAllListeners();
        mPlayButton.onClick.RemoveAllListeners();

        Actions.HotSpotSelect -= HotSpotSelectAct;
    }

    private void HotSpotSelectAct(CamDrop drop, string title, string detail)
    {
        mCamController.SetHotSpot(drop);

        mPanelCradle.Enable(false);

        mDetaillPanel.UI.Enable(true);
        mDetaillPanel.Init(title, detail);

        mHotspots.SetActive(false);

        mBackButton.gameObject.SetActive(true);
    }
}
