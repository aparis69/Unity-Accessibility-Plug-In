using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CBFixGUI : MonoBehaviour 
{
    public enum ColorBlindnessType
    {
        NormalVision = 0,
        Protanopia = 1,
        //Protanomaly = 2,
        Deuteranopia = 2,
        //Deuteranomaly = 4,
        Tritanopia = 3,
        //Tritanomaly = 6,
        //Achromatopsia = 7,
        //Achromanomaly = 8
    }    
    public ColorBlindnessType Type = ColorBlindnessType.NormalVision;
    public ColorBlindnessType updateType
    {
        get
        {
            return Type;
        }
        set
        {
            if (Type != value)
            {
                Type = value;
                ApplyFix();
            }
        }
    }

    private Button[] _BList;
    private bool firstRun;
    private Dictionary<Button, Color> _OriginalButtonColours;
    private Text[] _TList;
    private Dictionary<Text, Color> _OriginalTextColours;

	// Use this for initialization
	void Start () 
    {
        _OriginalButtonColours = new Dictionary<Button, Color>();
        _OriginalTextColours = new Dictionary<Text, Color>();
        
        firstRun = false;
        ApplyFix();       
	}

    private void ApplyFix()
    {
        if(_BList == null)
            _BList = (Button[])FindObjectsOfType(typeof(Button));

        if(_TList == null)
            _TList = (Text[])FindObjectsOfType(typeof(Text));

        if(firstRun == false)
        {
            foreach (Button B in _BList)            
                _OriginalButtonColours.Add(B, B.image.color); 
            
            foreach (Text T in _TList)
                _OriginalTextColours.Add(T, T.color);
            
            firstRun = true;
        }

        foreach (Button B in _BList)        
            FixButtonColor(B);

        foreach (Text T in _TList)
            FixTextColor(T);
    }


    private void FixButtonColor(Button B)
    {
        Color _originalcolour;
        Color _newcolour;


        switch (Type)
        {
            default:
            case ColorBlindnessType.NormalVision:
                _OriginalButtonColours.TryGetValue(B, out _newcolour);
                B.image.color = _newcolour;
                break;
            case ColorBlindnessType.Protanopia:
                _OriginalButtonColours.TryGetValue(B, out _originalcolour);

                if (_originalcolour.r >= 0.784f && (_originalcolour.b >= 0.0f && _originalcolour.b <= 0.235f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 0.274f))
                {
                    _newcolour = new Color(0.004f, 0.427f, 1.0f, _originalcolour.a);                    
                    B.image.color = _newcolour;
                }
                else if ((_originalcolour.r >= 225/255f && _originalcolour.b <= 1.0f) && (_originalcolour.b >= 1/255f && _originalcolour.b <= 25/255f) && (_originalcolour.g >= 225/255f && _originalcolour.g <= 1.0f))
                {
                    _newcolour = new Color(125/255f, 125/255f, 125/255f, _originalcolour.a);
                    
                    B.image.color = _newcolour;
                }
                else
                {
                    break;
                }
                break;
            case ColorBlindnessType.Deuteranopia:
                 _OriginalButtonColours.TryGetValue(B, out _originalcolour);
                 if ((_originalcolour.r >= 225/255f && _originalcolour.r <= 1.0f) && (_originalcolour.b >= 100/255f && _originalcolour.b <= 155/255f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 30/255f))
                {
                    _newcolour = new Color(0.004f, 0.427f, 1.0f, _originalcolour.a);
                    B.image.color = _newcolour;
                }                
                break;
            case ColorBlindnessType.Tritanopia:
                _OriginalButtonColours.TryGetValue(B, out _originalcolour);
                 if ((_originalcolour.r >= 225/255f && _originalcolour.r <= 1.0f) && (_originalcolour.b >= 225/255f && _originalcolour.b <= 1.0f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 120/255f))
                {
                    _newcolour = new Color(221/255f, 237/255f, 239/255f, _originalcolour.a);
                    B.image.color = _newcolour;
                }     
                break;
        } 
    }

    private void FixTextColor(Text T)
    {
        Color _originalcolour;
        Color _newcolour;


        switch (Type)
        {
            default:
            case ColorBlindnessType.NormalVision:
                _OriginalTextColours.TryGetValue(T, out _newcolour);
                T.color = _newcolour;
                break;
            case ColorBlindnessType.Protanopia:
                _OriginalTextColours.TryGetValue(T, out _originalcolour);

                if (_originalcolour.r >= 0.784f && (_originalcolour.b >= 0.0f && _originalcolour.b <= 0.235f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 0.274f))
                {
                    _newcolour = new Color(0.004f, 0.427f, 1.0f, _originalcolour.a);                    
                    T.color = _newcolour;
                }
                else if ((_originalcolour.r >= 225 / 255f && _originalcolour.b <= 1.0f) && (_originalcolour.b >= 1 / 255f && _originalcolour.b <= 25 / 255f) && (_originalcolour.g >= 225 / 255f && _originalcolour.g <= 1.0f))
                {
                    _newcolour = new Color(125 / 255f, 125 / 255f, 125 / 255f, _originalcolour.a);

                    T.color = _newcolour;
                }
                else
                {
                    break;
                }
                break;
            case ColorBlindnessType.Deuteranopia:
                _OriginalTextColours.TryGetValue(T, out _originalcolour);
                if ((_originalcolour.r >= 225 / 255f && _originalcolour.r <= 1.0f) && (_originalcolour.b >= 100 / 255f && _originalcolour.b <= 155 / 255f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 30 / 255f))
                {
                    _newcolour = new Color(0.004f, 0.427f, 1.0f, _originalcolour.a);
                    T.color = _newcolour;
                }
                break;
            case ColorBlindnessType.Tritanopia:
                _OriginalTextColours.TryGetValue(T, out _originalcolour);
                if ((_originalcolour.r >= 225 / 255f && _originalcolour.r <= 1.0f) && (_originalcolour.b >= 225 / 255f && _originalcolour.b <= 1.0f) && (_originalcolour.g >= 0.0f && _originalcolour.g <= 120 / 255f))
                {
                    _newcolour = new Color(221 / 255f, 237 / 255f, 239 / 255f, _originalcolour.a);
                    T.color = _newcolour;
                }
                break;
        }
    }
	






	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.G))
            updateType = (ColorBlindnessType)(((int)updateType + 1) % 4);
	}
}
