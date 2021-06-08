using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    //public UnityEngine.UI.InputField userInput;
    public InputField userInput;   //making this public so we can access it inside Unity. 
    public Text outputText;
    public Button guessButton;

    private int randomNumber;
    private bool flagWon = false;
    private int minNum=0;   //int values are by default assigned 0 by Unity.
    private int maxNum=5;
    private int countTries = 0;

    // Start is called before the first frame update
    void Start()     //private by default
    {
        ResetValues();
    }
    private void ResetValues()
    {
        randomNumber = GetRandomNumber(minNum, maxNum);
        //Debug.Log("Random number generated : "+randomNumber);
        if (flagWon)
        {
            userInput.text = "";
            outputText.text = "You Won!(Tries: "+countTries+") - Guess a number between " + minNum + " and " + maxNum;
            flagWon = false;
            countTries = 0;
        }
        else
        {
            outputText.text = "Guess a number between " + minNum + " and " + maxNum;
        }
    }
    /*
    // Update is called once per frame
    void Update()    //private by default
    {
        
    }
    */

    public void OnButtonClick()   //is accessable from outside this script
    {


        string userInputTextValue = userInput.text ;
        if (userInputTextValue != null && userInputTextValue!="")
        {
            countTries += 1;   //count the tries only if the user enters a number.
            int userInputIntValue = int.Parse(userInputTextValue);
            if (userInputIntValue == randomNumber)
            {
                //Debug.Log("Correct!");
                outputText.text = "Correct!";
                //guessButton.interactable=false;  //deactivating the button
                flagWon = true;
                ResetValues();
            }
            else if(userInputIntValue>randomNumber)
            {
                //Debug.Log("Try a lower value..");
                outputText.text = "Try Lower!";
            }
            else
            {
                //Debug.Log("Try a larger value..");
                outputText.text = "Try Higher!";
            }
        }
        else
        {
            //Debug.Log("Please enter a whole number value");
            outputText.text = "Please enter a number";
            
        }

        //Debug.Log("Who clicked me?");   //logs a message to the unity console
        //Debug.Log("The Random number value is : " + randomNumber);


        //Comparison by converting to string
//        if (userInput.text == randomNumber.ToString())
//        {
//            Debug.Log("YES! WON IT");
//        }
    }


    private int GetRandomNumber(int min,int max)
    {
        //returns a float randomly chosen from the specifiedrange which is then casted to int.
        //int randomNum= (int)Random.Range((float)min, (float)max);
        int randomNum = Random.Range(min,max+1);  //cuz max is exclusive
        return randomNum;
    }

}
