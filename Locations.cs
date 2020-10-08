/* Copywrite (C) 2020 Callum McIsaac All Rights Reserved */

using System;


public class Locations
{
    public bool canGoR;
    public bool canGoL;
    public bool canGoU;
    public bool canGoD;

    public Locations( bool canGoR, bool canGoL, bool canGoU, bool canGoD )
    {
        this.canGoR = canGoR;
        this.canGoL = canGoL;
        this.canGoU = canGoU;
        this.canGoD = canGoD;

    }


}