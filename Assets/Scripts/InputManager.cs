using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputField input_Nil;
    [SerializeField] private InputField input_TB1;
    [SerializeField] private InputField input_TB2;
    [SerializeField] private InputField input_Miltogen;
    [SerializeField] private Text resultText;




    public void OnCalculateButtonClicked()
    {
        float nil = 0;
        float tb1 = 0;
        float tb2 = 0;
        float miltogen = 0;

		nil = GetValueFromInputField(input_Nil);
		tb1 = GetValueFromInputField(input_TB1);
		tb2 = GetValueFromInputField(input_TB2);
		miltogen = GetValueFromInputField(input_Miltogen);

		/*if (input_Nil != null && input_Nil.text != "" && input_Nil.text != null)
        {
            nil = (float.Parse(input_Nil.text)) * 1.0f;
        }

        if (input_TB1 != null && input_TB1.text != "" && input_TB1.text != null)
        {
            tb1 = (float.Parse(input_TB1.text)) * 1.0f;
        }

        if (input_TB2 != null && input_TB2.text != "" && input_TB2.text != null)
        {
            tb2 = (float.Parse(input_TB2.text)) * 1.0f;
        }

        if (input_Miltogen != null && input_Miltogen.text != "" && input_Miltogen.text != null)
        {
            miltogen = (float.Parse(input_Miltogen.text)) * 1.0f;
        }*/

		Debug.Log("Nil is " + nil + " Tab 1  " + tb1 + "  Tb2 " + tb2 + " miltogen " + miltogen);


        int result = CalculationResult(nil, tb1, tb2, miltogen);

        string testString;

        switch (result)
        {
            case -1:
                testString = "Negative";
                break;
            case 0:
                testString = "IndeterMinate";
                break;
            case 1:
                testString = "Positive";
                break;

            default:
                testString = "Failed To Calculate";
                break;
        }

        resultText.text = testString;


    }


	private float GetValueFromInputField(InputField inputField)
	{
		float result = 0;

		if (inputField != null && inputField.text != "" && inputField.text != null)
		{
			result = (float.Parse(inputField.text)) * 1.0f;
		}
		if (result > 10.0f)
			result = 10.0f;

		return result;
	}

    public int CalculationResult(float nil, float tb1, float tb2, float miltogen)
    {
        float tb1_Minus_nil = tb1 - nil;
        float tb2_Minus_nil = tb2 - nil;
        float miltogen_Minus_nil = miltogen - nil;

        int result = 0;

		Debug.Log("tb1- nil = " + tb1_Minus_nil + "  tb2-Nil " + tb2_Minus_nil + "   milatagon - nil  " + miltogen_Minus_nil);

        if (nil > 8.0f)
        {
            return 0;
        }

        if ((tb1_Minus_nil >= 0.35f && tb1_Minus_nil >= (nil * 0.25f)) ||
            (tb2_Minus_nil >= 0.35f && tb2_Minus_nil >= (nil * 0.25f))
          )
        {
            result = 1;
        }
        else
        {
            if (miltogen_Minus_nil >= 0.5f)
                result = -1;
            else
                result = 0;
        }

        return result;
    }

	public void OnChangeEditTextValue()
	{
		resultText.text = "?";
	}
}
