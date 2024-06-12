using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("menu");

        //SceneManager.LoadScene(1);
    }
    public void ChooseFood1()
    {
        SceneManager.LoadScene("½µªo»æ");
    }
    public void ChooseFood2()
    {
        SceneManager.LoadScene("»ñ±ù¶p");
    }
    public void ChooseFood3()
    {
        SceneManager.LoadScene("¦×¶ê");
    }
    public void ChooseFood4()
    {
        SceneManager.LoadScene("Âû¦×¶º");
    }

    public void ChooseFood11()
    {
        SceneManager.LoadScene("taiwan(Scallion_pancake)");
    }
    public void ChooseFood22()
    {
        SceneManager.LoadScene("taiwan(pineapple_cake) 1");
    }
    public void ChooseFood33()
    {
        SceneManager.LoadScene("taiwan(chickenrice)");
    }
    public void ChooseFood44()
    {
        SceneManager.LoadScene("taiwan(meatballs)");
    }
    public void CloseChoose()
    {
        SceneManager.LoadScene("map");

        //SceneManager.LoadScene(1);
    }
    public void test()
    {
        SceneManager.LoadScene("test");

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
