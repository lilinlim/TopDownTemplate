using UnityEngine.InputSystem;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //menu doesn't pop up as soon as we open the game
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //command to open menu
        if (Keyboard.current.tabKey.wasPressedThisFrame) {
            //change to what the menu canvas currently isn't
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}
