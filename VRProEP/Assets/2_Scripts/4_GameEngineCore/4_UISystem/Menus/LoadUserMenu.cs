﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VRProEP.GameEngineCore;

public class LoadUserMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject experimentMenu;
    public GameObject userOptionsMenu;
    public Dropdown availableUserDropdown;
    public LogManager logManager;

    private List<string> userList = new List<string>();
    private int selectedUser = 0;
    private string userDataFolder;

    // Get list of available users when enabling menu.
    private void OnEnable()
    {
        // Get the data folder
        userDataFolder =  Application.persistentDataPath + "/UserData";

        // Empty all options.
        availableUserDropdown.ClearOptions();

        // Get all available user IDs
        string[] availableUsers = null;
        try
        {
            availableUsers = Directory.GetDirectories(userDataFolder);
        }
        catch
        {
            Directory.CreateDirectory(userDataFolder);
            availableUsers = Directory.GetDirectories(userDataFolder);
        }
        // Clear list
        userList.Clear();
        // Add an empty one as default to force selection.
        userList.Add(string.Empty);

        // Add them to the user list
        foreach (string user in availableUsers)
        {
            userList.Add(user.Substring(userDataFolder.Length + 1));
        }
        // Add the options to the dropdown
        availableUserDropdown.AddOptions(userList);
        
    }

    public void UpdatedSelectedUser(int selectedUser)
    {
        this.selectedUser = selectedUser;
    }

    public void LoadSelectedUser()
    {
        if (selectedUser != 0)
        {
            // Load data
            SaveSystem.LoadUserData(userList[selectedUser]);

            // Return to main menu
            experimentMenu.GetComponent<MainMenu>().loadedUser = true;
            ReturnToExperimentMenu();
        }
        else
            logManager.DisplayInformationOnLog(3.0f, "Select a valid user.");
    }

    public void ReturnToUserOptionsMenu()
    {
        userOptionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToExperimentMenu()
    {
        // Clear dropdown
        availableUserDropdown.ClearOptions();
        // Return to main menu
        experimentMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        // Clear dropdown
        availableUserDropdown.ClearOptions();
        // Return to main menu
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
