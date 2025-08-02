using System;
using System.Collections.Generic;
using System.Linq;

// Cls for Scripture Reference
public class Ref
{
    private string _bok; // Book
    private int _chp;    // Chapter
    private int _vrs;    // Verse start
    private int _vre;    // Verse end (if range)

    // Ctor for single verse
    public Ref(string bok, int chp, int vrs)
    {
        _bok = bok;
        _chp = chp;
        _vrs = vrs;
        _vre = vrs;
    }

    // Ctor for verse range
    public Ref(string bok, int chp, int vrs, int vre)
    {
        _bok = bok;
        _chp = chp;
        _vrs = vrs;
        _vre = vre;
    }

    // Get ref as str
    public string GetStr()
    {
        if (_vrs == _vre)
            return $"{_bok} {_chp}:{_vrs}";
        else
            return $"{_bok} {_chp}:{_vrs}-{_vre}";
    }
}

// Cls for Word in scripture
public class Wrd
{
    private string _txt; // Word text
    private bool _hid;   // Is hidden

    public Wrd(string txt)
    {
        _txt = txt;
        _hid = false;
    }

    public void Hid() => _hid = true;
    public bool IsHid() => _hid;
    public string GetTxt() => _hid ? new string('_', _txt.Length) : _txt;
}

// Cls for Scripture
public class Scr
{
    private Ref _ref;    // Reference
    private List<Wrd> _wrd; // Words list

    public Scr(Ref refer, string txt)
    {
        _ref = refer;
        _wrd = txt.Split(' ').Select(w => new Wrd(w)).ToList();
    }

    // Disp scripture
    public void Disp()
    {
        Console.WriteLine(_ref.GetStr());
        Console.WriteLine(string.Join(" ", _wrd.Select(w => w.GetTxt())));
    }

    // Hid random words
    public bool HidRnd(int num)
    {
        var vis = _wrd.Where(w => !w.IsHid()).ToList();
        if (!vis.Any()) return false;

        var rnd = new Random();
        var sel = vis.OrderBy(x => rnd.Next()).Take(Math.Min(num, vis.Count)).ToList();
        sel.ForEach(w => w.Hid());
        return true;
    }

    // All words hid?
    public bool AllHid() => _wrd.All(w => w.IsHid());
}

// Main prog
public class Prog
{
    static void Main()
    {
        // Init sample scripture
        var ref1 = new Ref("Mormon", 9, 21);
        var txt1 = "Behold, I say unto you, that he that believeth on Christ, without doubting at all,Whatever you ask the Father in the name of Christ, it will be granted to you; and this promise is for all, even to the ends of the earth.";
        var scr1 = new Scr(ref1, txt1);

        // Main loop
        while (true)
        {
            Console.Clear();
            scr1.Disp();

            if (scr1.AllHid()) break;

            Console.Write("\nPress Enter to delete a word and memorize it. ");
            var inp = Console.ReadLine();

            if (inp?.ToLower() == "quit") break;

            scr1.HidRnd(3); // Hide 3 words each time
        }
    }
}
