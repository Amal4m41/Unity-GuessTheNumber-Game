using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    //public UnityEngine.UI.InputField userInput;
    public InputField userInput;   //making this public so we can access it inside Unity. 
    public int randomNumber;

    // Start is called before the first frame update
    void Start()     //private by default
    {
        //returns a float randomly chosen from the specified range which is then casted to int.
        randomNumber = (int)Random.Range(1f,100f);  
    }

    // Update is called once per frame
    void Update()    //private by default
    {
        
    }

    public void OnButtonClick()   //is accessable from outside this script
    {
        
        string userInputTextValue = userInput.text ;
        if (userInputTextValue != null && userInputTextValue!="")
        {
            int userInputIntValue = int.Parse(userInputTextValue);
            if (userInputIntValue == randomNumber)
            {
                Debug.Log("Correct!");
            }
            else if(userInputIntValue>randomNumber)
            {
                Debug.Log("Try a lower value..");
            }
            else
            {
                Debug.Log("Try a larger value..");
            }
        }
        else
        {
            Debug.Log("Please enter a whole number value");
        }

        //Debug.Log("Who clicked me?");   //logs a message to the unity console
        //Debug.Log("The Random number value is : " + randomNumber);


        //Comparison by converting to string
//        if (userInput.text == randomNumber.ToString())
//        {
//            Debug.Log("YES! WON IT");
//        }
    }
}
