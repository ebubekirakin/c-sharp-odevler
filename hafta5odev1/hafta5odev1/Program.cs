using System;

class X
{
    public int i = 101; public X() { i = i++ + i-- - i; }
    public static int staticMethod(int i) { return --i; }
}
class Y : X { public Y() { Console.Write(X.staticMethod(i)); } }
class soru { static void Main() { Y y = new Y(); } }