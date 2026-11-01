using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //to open to the default first tab each time it's opened
        ActivateTab(0);
    }

    //
    public void ActivateTab(int tabNo){
        //deactivating all tabs
        for(int i = 0; i < pages.Length; i++){
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }

        //activating the tab we click on
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;
    }
}
