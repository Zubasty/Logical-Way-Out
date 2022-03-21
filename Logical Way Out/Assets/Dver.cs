using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1) отрицание; 2) конъюнкция; 3) дизъюнкция; 4) логическое следование; 5) сумма по модулю 2 и эквивалентность.
// ∧ ∨ → ≡ ¬ ⊕
public class Dver_Func
{
    private string _Func_ish;
    private List<char> _Func_vih_str = new List<char>();
    private string _Preobr_str;
    private bool[] _per;
    public Dver_Func(int count_per, string Func)
    {
        _per = new bool[count_per];
        _Func_ish = Func;
        Func_Stack_Str(_Func_ish);
    }
    public bool Func_Raschet()
    {
        _Func_vih_str.Clear();
        foreach (char k in _Preobr_str)
        {
            _Func_vih_str.Add(k);
        }
        while (_Func_vih_str.Count != 1)
        {
            int i = 0;
            while (_Func_vih_str[i] != '¬' && _Func_vih_str[i] != '∧' && _Func_vih_str[i] != '∨' && _Func_vih_str[i] != '→' && _Func_vih_str[i] != '⊕' && _Func_vih_str[i] != '≡') // ¬∧∨→⊕≡
            {
                i++;
            }
            if (_Func_vih_str[i] == '¬')
            {
                switch (_Func_vih_str[i - 1])
                {
                    case 'x':
                        if (_per[0])
                            _Func_vih_str[i - 1] = '0';
                        else
                            _Func_vih_str[i - 1] = '1';
                        break;
                    case 'y':
                        if (_per[1])
                            _Func_vih_str[i - 1] = '0';
                        else
                            _Func_vih_str[i - 1] = '1';
                        break;
                    case 'z':
                        if (_per[2])
                            _Func_vih_str[i - 1] = '0';
                        else
                            _Func_vih_str[i - 1] = '1';
                        break;
                    case 'w':
                        if (_per[3])
                            _Func_vih_str[i - 1] = '0';
                        else
                            _Func_vih_str[i - 1] = '1';
                        break;
                    case '0':
                        _Func_vih_str[i - 1] = '1';
                        break;
                    case '1':
                        _Func_vih_str[i - 1] = '0';
                        break;
                }
                _Func_vih_str.RemoveAt(i);
                Debug.Log("Значения строки с фукнцией " + _Func_vih_str[0]);
            }
            else
            {
                bool A = new bool();
                bool B = new bool();
                int oper = -1;
                A = Che_za_per(_Func_vih_str[i - 2]);
                B = Che_za_per(_Func_vih_str[i - 1]);
                switch (_Func_vih_str[i])// ∧∨→≡⊕
                {
                    case '∧':
                        oper = 0;
                        break;
                    case '∨':
                        oper = 1;
                        break;
                    case '→':
                        oper = 2;
                        break;
                    case '≡':
                        oper = 3;
                        break;
                    case '⊕':
                        oper = 4;
                        break;
                }
                if (Posch_Func(A, B, oper))
                {
                    _Func_vih_str[i] = '1';
                }
                else
                {
                    _Func_vih_str[i] = '0';
                }
                _Func_vih_str.RemoveAt(i - 1);
                _Func_vih_str.RemoveAt(i - 2);
            }
        }
        if (Che_za_per(_Func_vih_str[0]))
            return true;
        else
            return false;
    }
    private void Func_Stack_Str(string ish_str)
    {
        string F = ish_str;
        Stack<char> Func_stack = new Stack<char>();
        for (int i = 0; i < F.Length; i++)
        {
            if (F[i] == '¬' || F[i] == '(')
            {
                Func_stack.Push(F[i]);
            }
            else if (F[i] == ')')
            {
                while (Func_stack.Peek() != '(')
                {
                    _Func_vih_str.Add(Func_stack.Pop());
                }
                Func_stack.Pop();
            }
            else if (F[i] == '⊕' || F[i] == '∧' || F[i] == '∨' || F[i] == '→' || F[i] == '≡') // ∧∨→≡⊕
            {
                if (Func_stack.Count != 0)
                {
                    switch (F[i])
                    {
                        case '∧':
                            while (Func_stack.Count != 0 && (Func_stack.Peek() == '¬' || Func_stack.Peek() == '∧'))
                                _Func_vih_str.Add(Func_stack.Pop());
                            Func_stack.Push(F[i]);
                            break;
                        case '∨':
                            while (Func_stack.Count != 0 && (Func_stack.Peek() == '¬' || Func_stack.Peek() == '∧' || Func_stack.Peek() == '∨'))
                                _Func_vih_str.Add(Func_stack.Pop());
                            Func_stack.Push(F[i]);
                            break;
                        case '→':
                            while (Func_stack.Count != 0 && (Func_stack.Peek() == '¬' || Func_stack.Peek() == '∧' || Func_stack.Peek() == '∨' || Func_stack.Peek() == '→'))
                                _Func_vih_str.Add(Func_stack.Pop());
                            Func_stack.Push(F[i]);
                            break;
                        default:
                            while (Func_stack.Count != 0 && (Func_stack.Peek() == '¬' || Func_stack.Peek() == '∧' || Func_stack.Peek() == '∨' || Func_stack.Peek() == '→' || Func_stack.Peek() == '⊕' || Func_stack.Peek() == '≡'))
                                _Func_vih_str.Add(Func_stack.Pop());
                            Func_stack.Push(F[i]);
                            break;
                    }
                }
                else
                {
                    Func_stack.Push(F[i]);
                }
            }
            else
            {
                _Func_vih_str.Add(F[i]);
            }
        }
        while (Func_stack.Count != 0)
            _Func_vih_str.Add(Func_stack.Pop());
        foreach (char k in _Func_vih_str)
        {
            _Preobr_str += k;
        }
    }
    public bool[] per
    {
        get { return _per; }
        set { _per = value; }
    }
    private bool Posch_Func(bool A, bool B, int Operac)
    {
        switch (Operac)
        {
            case 0:
                return (A && B);
            case 1:
                return (A || B);
            case 2:
                return (!A || B);
            case 3:
                return (A == B);
            case 4:
                return (!(A == B));
        }
        return true;
    }
    private bool Che_za_per(char vh)
    {
        switch (vh)
        {
            case 'x':
                return _per[0];
            case 'y':
                return _per[1];
            case 'z':
                return _per[2];
            case 'w':
                return _per[3];
            case '1':
                return true;
            case '0':
                return false;
        }
        return false;
    }
    /*public void Izm_znach_per(char p, bool z)
    {
        switch (p)
        {
            case 'x':
                _per[0] = z;
                break;
            case 'y':
                _per[1] = z;
                break;
            case 'z':
                _per[2] = z;
                break;
            case 'w':
                _per[3] = z;
                break;
        }
    }*/
    public string Func_Str
    {
        get { return _Func_ish; }
    }
}

public class Dver : MonoBehaviour
{
    [SerializeField] public int count_per;
    [SerializeField] private string Func;
    private bool Dver_otkr = false;
    private bool znach_func;
    private Dver_Func Dv;
    private Animator anim;
    private BoxCollider2D bc2;
    [SerializeField] private TextMesh Numb_func;
    // Start is called before the first frame update
    void Start()
    {
        Dv = new Dver_Func(count_per, Func); // ∧ ∨ → ≡ ¬ ⊕
        anim = GetComponent<Animator>();
        znach_func = Dv.Func_Raschet();
        bc2 = GetComponent<BoxCollider2D>();
        Raschet_Func();
    }
    public void Raschet_Func() //7) Если номер всё еще не -1, то меняем значение переменной с этим номером и чекаем чо тогда стало с этой функцией
    {
        if (kn.numb_p != -1)
        {
            Debug.Log(kn.numb_p);
            Dv.per[kn.numb_p] = kn.perem[kn.numb_p];
            znach_func = Dv.Func_Raschet();
            Debug.Log("Значение функции " + znach_func);
        }
        Otkr_Dver();
    }

    private void Otkr_Dver()
    {
        if (!znach_func && Dver_otkr || znach_func && !Dver_otkr)
        {
            anim.SetTrigger("Дверь пересчитала функцию");
            Dver_otkr = !Dver_otkr;
        }
        bc2.isTrigger = Dver_otkr;
        if (Dver_otkr)
        {
            Numb_func.color = Color.green;
        }
        else
        {
            Numb_func.color = Color.red;
        }
    }

    public string String_Func()
    {
        if (Dver_otkr)
            return Numb_func.text + "=" + Func + " - " + "истина";
        else
            return Numb_func.text + "=" + Func + " - " + "ложь";
    }
    // Update is called once per frame
    void Update()
    {

    }
}