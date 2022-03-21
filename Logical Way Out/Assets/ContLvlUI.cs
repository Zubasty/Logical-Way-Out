using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContLvlUI : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] Text text_func;
    [SerializeField] Dver[] Dveri;
    [SerializeField] Text schet_nazh_text;
    [SerializeField] Text record_text;
    [SerializeField] InputField name_record;
    [SerializeField] GameObject Panel_record;
    private int schet_nazh = 0;
    // Start is called before the first frame update
    void Start()
    {
        Panel_record.SetActive(false);
        kn.kol_per = 0;
        for (int i = 0; i < Dveri.Length; i++)
        {
            if (Dveri[i].count_per > kn.kol_per)
                kn.kol_per = Dveri[i].count_per;
        }
        string[] per = new string[kn.kol_per];
        for (int i = 0; i < kn.kol_per; i++)
        {
            switch (i)
            {
                case 0:
                    per[i] = "x";
                    break;
                case 1:
                    per[i] = "y";
                    break;
                case 2:
                    per[i] = "z";
                    break;
                case 3:
                    per[i] = "w";
                    break;
            }
            per[i] += " = 0";
        }
        String_Obnovl(per);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void end_menu()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4 && SceneManager.GetActiveScene().buildIndex <= 11)
        {
            SceneManager.LoadScene("Obuch_menu");
        }
        if (SceneManager.GetActiveScene().buildIndex >= 12 && SceneManager.GetActiveScene().buildIndex <= 19)
        {
            SceneManager.LoadScene("Game_menu");
        }
    }
    public void endlvl()
    {
        string n_k = SceneManager.GetActiveScene().name + "_record_score";
        if (schet_nazh<=PlayerPrefs.GetInt(n_k) || PlayerPrefs.GetInt(n_k)==-1)
        {
            Panel_record.SetActive(true);
            if(schet_nazh%10 == 1 && schet_nazh%100 != 11)
            {
                record_text.text = "Ты прошел уровень за " + schet_nazh + " нажатие";
            }
            else if(schet_nazh % 10 != 0 && schet_nazh % 10 <= 4 && (schet_nazh % 100 < 11 || schet_nazh % 100 > 14))
            {
                record_text.text = "Ты прошел уровень за " + schet_nazh + " нажатия";
            }
            else
            {
                record_text.text = "Ты прошел уровень за " + schet_nazh + " нажатий";
            }            
        }
        else
        {
            end_menu();
        }
    }
    public void endlvlok()
    {
        string n_n = SceneManager.GetActiveScene().name + "_record_name";
        string n_k = SceneManager.GetActiveScene().name + "_record_score";
        PlayerPrefs.SetInt(n_k,schet_nazh);
        PlayerPrefs.Save();
        PlayerPrefs.SetString(n_n, name_record.text);
        PlayerPrefs.Save();
        end_menu();
    }
    public void String_Obnovl(string[] per)
    {
        text_func.text = "";
        for (int i = 0; i < per.Length; i++)
        {
            string k = per[i];
            text_func.text += k + "\n";
        }
        for (int i = 0; i < Dveri.Length; i++)
        {
            string k = Dveri[i].String_Func();
            text_func.text += k + "\n";
        }
    }
    public void Menu_Pan()
    {
        Panel.SetActive(!Panel.activeSelf);
    }

    public void Obnovi_schet()
    {
        schet_nazh++;
        schet_nazh_text.text = "Кол-во нажатий: " + schet_nazh;
    }
    public void func_str()
    {
        text_func.enabled = !text_func.enabled;
    }
}

