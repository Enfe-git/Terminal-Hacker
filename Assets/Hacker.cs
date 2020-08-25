using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

 

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid input, try again.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    //Shows the main menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu; 
        Terminal.ClearScreen();
        Terminal.WriteLine("Henlo yes this is Bread");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1. Bakery");
        Terminal.WriteLine("2. Bread bucket");
        Terminal.WriteLine("Enter your selection: ");
    }
}
