
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "roll", "bread", "slice" };
    string[] level2Passwords = { "loaf", "breadward", "breadcrumbs"};


    // Game state
    int level;
    string password;
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
        } else if (currentScreen == Screen.Password)
        {
            GuessPassword(input);
        }
    }


    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
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
        switch(level)
        {

            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password: ");
    }

    //Shows the main menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu; 
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1. Bakery");
        Terminal.WriteLine("2. Bread bucket");
        Terminal.WriteLine("Enter your selection: ");
    }

    void GuessPassword(string input)
    {
        if (input.ToLower() == password)
        {
            currentScreen = Screen.Win;
            Terminal.WriteLine("Congratulations! Type in 'menu' to go back to the main menu.");
        }
        else
        {
            Terminal.WriteLine("Try again.");
        }
    }
}
