using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value <= 0 ? 0 : value; }
    }


    private List<string> _maxPowers = new List<string>();
    private int _pride = 0;
    private int _greed = 0;
    private int _lust = 0;
    private int _envy = 0;
    private int _gluttony = 0;
    private int _wrath = 0;
    private int _sloth = 0;
    public List<string> MaxPowers { get; private set; }
    /// <summary>
    /// Kibir
    /// </summary>
    public int Pride
    {
        get { return _pride; }
        set
        {
            if (value < -10 || value > 10) return;
            _pride = value;
            ValueCheck(_pride, "Pride");
        }
    }
    /// <summary>
    /// Acgozluluk 
    /// </summary>
    public int Greed
    {
        get { return _greed; }
        set
        {
            if (value < -10 || value > 10) return;
            _greed = value;
            ValueCheck(_greed, "Greed");
        }
    }
    /// <summary>
    /// Sehvet
    /// </summary>
    public int Lust
    {
        get { return _lust; }
        set
        {
            if (value < -10 || value > 10) return;
            _lust = value;
            ValueCheck(_lust, "Lust");
        }
    }
    /// <summary>
    /// Kiskanclik
    /// </summary>
    public int Envy
    {
        get { return _envy; }
        set
        {
            if (value < -10 || value > 10) return;
            _envy = value;
            ValueCheck(_envy, "Envy");
        }
    }
    /// <summary>
    /// Oburluk
    /// </summary>
    public int Gluttony
    {
        get { return _gluttony; }
        set
        {
            if (value < -10 || value > 10) return;
            _gluttony = value;
            ValueCheck(_gluttony, "Gluttony");
        }
    }
    /// <summary>
    /// Ofke
    /// </summary>
    public int Wrath
    {
        get { return _wrath; }
        set
        {
            if (value < -10 || value > 10) return;
            _wrath = value;
            ValueCheck(_wrath, "Wrath");
        }
    }
    /// <summary>
    /// Tembellik
    /// </summary>
    public int Sloth
    {
        get { return _sloth; }
        set
        {
            if (value < -10 || value > 10) return;
            _sloth = value;
            ValueCheck(_sloth, "Sloth");
        }
    }

    void ValueCheck(int value, string powerType)
    {
        if (value == 10)
        {
            _maxPowers.Add("+" + powerType);
        }
        else if (value == -10)
        {
            _maxPowers.Add("-" + powerType);
        }
    }
}/**/
