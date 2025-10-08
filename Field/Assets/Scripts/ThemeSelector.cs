using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeSelector : MonoBehaviour
{
    [SerializeField] List<GameObject> themObjs= new List<GameObject>();
    [SerializeField] Theme theme;

    [Space]
    [SerializeField] Button themDefault;
    [SerializeField] Button themOne;
    [SerializeField] Button themTwo;

    private void OnEnable()
    {
        themDefault.onClick.AddListener(() => SelectTheme(Theme.def));
        themOne.onClick.AddListener(() => SelectTheme(Theme.one));
        themTwo.onClick.AddListener(() => SelectTheme(Theme.two));
    }

    private void OnDisable()
    {
        themDefault.onClick.RemoveAllListeners();
        themOne.onClick.RemoveAllListeners();
        themTwo.onClick.RemoveAllListeners();
    }

    public void SelectTheme(Theme mTheme)
    {
        theme = mTheme;

        themObjs[0].SetActive(theme == Theme.def);
        themObjs[1].SetActive(theme == Theme.one);
        themObjs[2].SetActive(theme == Theme.two);
    }

}

public enum Theme {one,two,def}
