using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records_contr : MonoBehaviour
{
    [SerializeField] Text[] rec_txt;
    [SerializeField] GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<rec_txt.Length; i++)
        {
            int k = new int();
            string name = "";
            string score = "";
            if(i<8)
            {
                k = i+1;
                name ="Obuch_lvl"+k +"_record_name";
                score = "Obuch_lvl" + k + "_record_score";
            }
            else
            {
                k = i - 7;
                name = "Comp_lvl" + k + "_record_name";
                score = "Comp_lvl" + k + "_record_score";
            }
            if(!PlayerPrefs.HasKey(score))
            {
                PlayerPrefs.SetInt(score, -1);
                PlayerPrefs.SetString(name, "Default");
            }
            if(PlayerPrefs.GetInt(score) != -1)
            {
                rec_txt[i].text = "Ваш рекорд: " + PlayerPrefs.GetString(name) + " " + PlayerPrefs.GetInt(score);
            }
            else
            {
                rec_txt[i].text = "Рекорда нет";
            }
            
        }

    }
    public void clear_record()
    {
        for (int i = 0; i < 16; i++)
        {
            int k = new int();
            string name = "";
            string score = "";
            if (i < 8)
            {
                k = i + 1;
                name = "Obuch_lvl" + k + "_record_name";
                score = "Obuch_lvl" + k + "_record_score";
            }
            else
            {
                k = i - 7;
                name = "Comp_lvl" + k + "_record_name";
                score = "Comp_lvl" + k + "_record_score";
            }
            PlayerPrefs.SetInt(score, -1);
            PlayerPrefs.SetString(name, "Default");
            if (PlayerPrefs.GetInt(score) != -1)
            {
                rec_txt[i].text = "Ваш рекорд: " + PlayerPrefs.GetString(name) + " " + PlayerPrefs.GetInt(score);
            }
            else
            {
                rec_txt[i].text = "Рекорда нет";
            }
        }

    }

    public void end_record()
    {
        Panel.SetActive(!Panel.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
