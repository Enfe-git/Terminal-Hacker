
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game configuration data
    string[] level1Passwords = { "roll", "bread", "slice" };
    string[] level2Passwords = { "loaf", "breadward", "breadcrumbs" };


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
        GetPassword();
        DisplayGame();
    }

    private void GetPassword()
    {
        switch (level)
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
    }

    private void DisplayGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine("Enter your password: ");
    }

    //Shows the main menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Type in 'menu' at any stage to get back to the main menu");
        Terminal.WriteLine("1. Bakery");
        Terminal.WriteLine("2. Bread bucket");
        Terminal.WriteLine("Enter your selection: ");
    }

    void GuessPassword(string input)
    {
        if (input.ToLower() == password)
        {
            DisplayWinScreen(); ;
        }
        else
        {
            DisplayGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a bread.");
                break;
            case 2:
                Terminal.WriteLine("Put it in the bucket.");
                break;
        }
        Terminal.WriteLine("Type in 'menu' to return to the main menu.");
    }
}
