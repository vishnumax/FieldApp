using UnityEngine;
public class AppController : MonoBehaviour
{
    [SerializeField] PanelUI mMainMenu;


    private void Start()
    {
        mMainMenu.Enable(true);
    }
}
