using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_digitalDisplay : MonoBehaviour
{
    [SerializeField]
    private Sprite[] characters;

    [SerializeField]
    private Sprite[] digits;

    public GameObject[] digitDisp;
    public SpriteRenderer[] digitSprR;

    private char tempDigit;
    public static bool dispChanged;

    public Sprite standrdSprite;

    private void Start()
    {
        dispChanged = false;

        for (int i = 0; i < digitDisp.Length; i++)
        {
            characters[i] = digitDisp[i].GetComponent<Sprite>();
            digitSprR[i] = digitDisp[i].GetComponent<SpriteRenderer>();
        }
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = standrdSprite;
        }

        
    }


    // Update is called once per frame
    void Update()
    {

        

        if (testkeypad.teststring.Length != 0)
        {
            tempDigit = testkeypad.teststring[testkeypad.teststring.Length -1];

            if (!dispChanged)
            {
                changeDisplay();
            }

        }
        for (int i = 0; i < digitDisp.Length; i++)
        {
            digitSprR[i].sprite = characters[i];
        }


    }
    private void changeDisplay()
    {
        switch (testkeypad.teststring.Length)
        {

            case 1:
                {

                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 2:
                {
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 3:
                {

                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 4:
                {
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 5:
                {
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 6:
                {
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                    break;
            case 7:
                {
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 8:
                {
                    characters[4] = characters[5];
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 9:
                {
                    characters[3] = characters[4];
                    characters[4] = characters[5];
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 10:
                {
                    characters[2] = characters[3];
                    characters[3] = characters[4];
                    characters[4] = characters[5];
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
            case 11:
                {
                    characters[1] = characters[2];
                    characters[2] = characters[3];
                    characters[3] = characters[4];
                    characters[4] = characters[5];
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];

                }
                break;
            case 12:
                {
                    characters[0] = characters[1];
                    characters[1] = characters[2];
                    characters[2] = characters[3];
                    characters[3] = characters[4];
                    characters[4] = characters[5];
                    characters[5] = characters[6];
                    characters[6] = characters[7];
                    characters[7] = characters[8];
                    characters[8] = characters[9];
                    characters[9] = characters[10];
                    characters[10] = characters[11];
                    characters[11] = digits[Mathf.RoundToInt((float)char.GetNumericValue(tempDigit))];
                }
                break;
        }
        dispChanged = true;
    }
}
