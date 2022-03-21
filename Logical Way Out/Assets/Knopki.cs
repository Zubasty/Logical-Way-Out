using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Knopka
{
    private bool _znach_per = false;
    private int _numb_per;
    public Knopka(int n)
    {
        _numb_per = n;
    }
    public int numb_per
    {
        get { return _numb_per; }
    }
    public bool znach_per
    {
        get { return _znach_per; }
        set { _znach_per = value; }
    }
}

public class kn
{
    public static bool[] perem = new bool[4];
    public static int numb_p = -1;
    public static bool proigr_anim;
    public static int kol_per;
}
public class Knopki : MonoBehaviour
{
    private Knopka knop;
    [SerializeField] int number;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        knop = new Knopka(number);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Soobshay_koresham() // 2)Коля нажимает кнопку
    {
        kn.numb_p = number; // 3)мы запоминаем номер кнопки
        Debug.Log("2) Теперь мы знаем номер кнопки " + kn.numb_p);
    }
    public void Operate() //6) если *ЧТО-ТО, НАДО ЕЩЕ ОПИСАТЬ ЧТО*, то запускаем визуальное оформление для кнопки
    {
        anim.SetBool("Нажимаем кнопку", true);
        knop.znach_per = !knop.znach_per;

    }

    public void MZHN_SNOVA_NAZHIMAT()
    {
        anim.SetBool("Нажимаем кнопку", false);
        kn.proigr_anim = false;
    }
    public int num
    {
        get { return number; }
    }
}