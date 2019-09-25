using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorBox
{
    public ColorBox() {
        rand = new System.Random();
    }

    System.Random rand;

    public Color RandColor() {
        return new Color(GetCrNum((float)rand.Next(255)),
            GetCrNum((float)rand.Next(255)),
            GetCrNum((float)rand.Next(255)));
    }

    public Color SetColorWithRGB(float r,float g,float b) {
        return new Color(GetCrNum(r),
            GetCrNum(g),
            GetCrNum(b));
    }

    float GetCrNum(float target) {
        return target / 255f;
    }
}
