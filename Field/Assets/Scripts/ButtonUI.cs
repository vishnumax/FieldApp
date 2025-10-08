using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent (typeof(Button))]
public class ButtonUI : MonoBehaviour
{
    Button mbutton;
    public Button MButton => mbutton;

    private void Awake()
    {
        mbutton = GetComponent<Button>();
    }

    private void OnDisable()
    {
        mbutton?.onClick.RemoveAllListeners();
    }
}

