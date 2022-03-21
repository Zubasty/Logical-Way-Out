using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per : MonoBehaviour
{
    [SerializeField] public Knopki[] Knopkas;
    [SerializeField] ContLvlUI UI;
    private bool control = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() // Когда Коля нажимает кнопку все кнопки нажимаются
    {
        if (kn.numb_p != -1) // 4) Когда номер кнопки стал отличным от -1, запускаем поиск кнопок с таким же номером
        {
            Debug.Log("3) Теперь мы запускаем все кнопки с этим номером " + kn.numb_p);
            Vse_kn(kn.numb_p);
        }
    }
    private string String_Per(int n, bool z)
    {
        string res = "";
        switch (n)
        {
            case 0:
                res += "x";
                break;
            case 1:
                res += "y";
                break;
            case 2:
                res += "z";
                break;
            case 3:
                res += "w";
                break;
        }
        if (z)
            res += " = 1";
        else
            res += " = 0";
        return res;
    }
    public void Vse_kn(int numb) // 5) Если номер кнопки такой же, как у той, что нажал Коля, происходит вызов ОПЕРАТЕ
    {
        string[] per = new string[kn.kol_per];
        bool p = true;
        foreach (Knopki knop in Knopkas)
        {
            if (knop.num == kn.numb_p)
            {
                if (p)
                {
                    kn.perem[kn.numb_p] = !kn.perem[kn.numb_p]; // один единствнный раз меняем значение переменной с этим номером
                    UI.Obnovi_schet();
                    p = false;
                }
                knop.Operate();
            }
            per[knop.num] = String_Per(knop.num, kn.perem[knop.num]);
        }
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1000f, 1000f), 0f);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.name == "Двери")
            {
                Debug.Log("4) Вот теперь то мы поменяли значения всех одинаковых кнопок и передаем инфу дверям");
                hitCollider.SendMessage("Raschet_Func", SendMessageOptions.DontRequireReceiver); // и пытаемся передать двери инфу про то что надо чекнуть ф-цию
            }
        }
        UI.String_Obnovl(per);
        kn.numb_p = -1;
    }
}