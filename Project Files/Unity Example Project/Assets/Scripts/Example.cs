/* This project may not be reproduced or selling anywhere without prior written permission of Electronic Brain.
 * Project Developed by : Srejon Khan, Game Programmer, Electronic Brain and Ashikur Rahman, Game Programmer,Electronic Brain
 * Email : support@electronicbrain.net 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartDLL;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public SmartPrinter smartPrinter = new SmartPrinter();

    public string headerDirectory;

    public InputField textInput;
    public Button printButton;



    void OnEnable()
    {
        printButton.onClick.AddListener(delegate { PrintDocument(); });
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PrintDocument()
    {
        smartPrinter.PrintDocument(textInput.text, @headerDirectory);
    }
}
