using Sandbox;

class Bin
{
    private string _denomination;
    private double _value;
    private int _count;

    // behaviors

    public Bin(string d, double v, int c) // This is a conrstuctor
    {
        _denomination = d;
        _value = v;
        _count = c;
    }

    // modifier method "Alter" Set method
    public void Alter(int delta)
    {
        _count += delta;
    }
    // accessor 'getter' methods 
    public string GetDenomintation() { return _denomination; }
    public int GetCount() { return _count; }
}