using System;
public class Node<T>
{
    private T value;
    private Node<T> next;

    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }

    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }

    public T GetValue()
    {
        return this.value;
    }
    public Node<T> GetNext()
    {
        return next;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    public bool HasNext()
    {
        return this.next != null;
    }

    public override string ToString()
    {
        string str = string.Empty;
        if (this.next == null)
            return $"[{this.value}, next]=>null";
        else
            return $"[{this.value}, next]=>{this.next}";
    }
}

public class Program
{
    //פעולה המקבלת מצביע לחוליה 
    //מחזירה אמת אם החוליות מסודרות בסדר עולה
    //ושקר אחרת
    //אורך הקלט n:
    //המקרה הגרוע:
    //הפעולה מתבצעת.... ובכל סיבוב הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: O(n)
    public static bool IsAscending(Node<int> lst)
    {
        Node<int> p = lst;
        if (p == null) return true;    //אם השרשרת ריקה אז זה לא יורד לכן עולה

        while (p != null && p.GetNext() != null)
        {
            if (p.GetValue() > p.GetNext().GetValue()) return false;
            p = p.GetNext();
        }
        return true;
    }

    //אורך הקלט n:
    //המקרה הגרוע:
    //הפעולה מבצעת ....  קריאות ובכל קריאה הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: O(n)

    //כמו קודם רק מימוש רקורסיבי
    public static bool IsAscendingRecursive(Node<int> p)
    {
        if (p == null) return true;
        if (p.GetNext() == null) return true;
        if (p.GetValue() > p.GetNext().GetValue()) return false;
        return IsAscendingRecursive(p.GetNext());
    }

    //פעולה גנרית המחזירה אמת אם 
    //x 
    //קיים בשרשרת החוליות 
    //lst
    //ושקר אחחרת
    //שימו לב שבפעולה גנרית אין 
    //לא ניתן להשתמש ב
    //==
    //יש להתשמש בפעולה של
    //object
    //Equals

    //אורך הקלט n:
    //המקרה הגרוע:
    //הפעולה מתבצעת.... ובכל סיבוב הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: O(n)

    public static bool IsExists<T>(Node<T> lst, T x)
    {
        Node<T> p = lst;

        while (p != null)
        {
            if (p.GetValue().Equals(x)) return true;
            p = p.GetNext();
        }
        return false;
    }
    //אורך הקלט n:
    //המקרה הגרוע:
    //הפעולה מבצעת ....  קריאות ובכל קריאה הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: O(n)


    public static bool IsExistsRecursive<T>(Node<T> lst, T x)
    {
        if (lst == null) return false;
        if (lst.GetValue().Equals(x)) return true;
        return IsExistsRecursive(lst.GetNext(), x);
    }



    public static void Main()
    {
        Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null

        Console.WriteLine(IsAscending(lst1));//should print True
        Console.WriteLine(IsAscendingRecursive(lst1));//should print True

        Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
        Console.WriteLine(IsAscending(lst2));//should print False
        Console.WriteLine(IsAscendingRecursive(lst2));//should print False
        Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
        Console.WriteLine(IsAscending(lst3));//should print False
        Console.WriteLine(IsAscendingRecursive(lst3));//should print False

        Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
        Console.WriteLine(IsExists(lst1, 5));//should print True
        Console.WriteLine(IsExists(lst4, 'i'));//should print True
        Console.WriteLine(IsExists(lst4, 'I'));//should print False
        Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
        Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
        Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False


    }


}