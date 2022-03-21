using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class contr_lvl_dostup
{
    public static bool[] Lvl_dostup = new bool[16];
}
public class Controller_menu : MonoBehaviour
{
    [SerializeField] Button[] Buttons;
    
    public void Default_nastroiki()
    {
        for(int i = 0; i < 8; i++)
        {
            string comp = "Comp_lvl" + (i+1).ToString() + "_dostup";
            string obuch = "Obuch_lvl" + (i + 1).ToString() + "_dostup";
            PlayerPrefs.DeleteKey(comp);
            PlayerPrefs.DeleteKey(obuch);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Obuch_lvl1_dostup",1);
        PlayerPrefs.SetInt("Comp_lvl1_dostup", 1);
        for (int i = 0; i < 8; i++)
        {
            int num = i + 1;
            string obuch = "Obuch_lvl" + num + "_dostup";
            if (PlayerPrefs.HasKey(obuch))
            {
                if (PlayerPrefs.GetInt(obuch) == 1)
                    contr_lvl_dostup.Lvl_dostup[i] = true;
                else
                    contr_lvl_dostup.Lvl_dostup[i] = false;
            }
            else
                contr_lvl_dostup.Lvl_dostup[i] = false;
            string comp = "Comp_lvl" + num + "_dostup";
            if (PlayerPrefs.HasKey(comp))
            {
                if (PlayerPrefs.GetInt(comp) == 1)
                    contr_lvl_dostup.Lvl_dostup[i+8] = true;
                else
                    contr_lvl_dostup.Lvl_dostup[i+8] = false;
            }
            else
                contr_lvl_dostup.Lvl_dostup[i+8] = false;
        }
        if(Buttons.Length!=0)
        {
            int k;
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                k = 0;
            }
            else
            {
                k = 8;
            }
            for (int i = 0; i < Buttons.Length; i++)
            {
                Image image = Buttons[i].GetComponent<Image>();
                if (!contr_lvl_dostup.Lvl_dostup[i + k])
                {
                    Buttons[i].interactable = false;
                    image.color = new Color(0, 0, 0, 50);
                }
                else
                {
                    Buttons[i].interactable = true;
                    image.color = new Color(255, 255, 255, 255);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LvlLoad(int numb)
    {
        SceneManager.LoadScene(numb);
    }
}
