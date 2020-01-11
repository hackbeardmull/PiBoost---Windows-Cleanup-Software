/*
 * Created by SharpDevelop.
 * User: dierk.piening
 * Date: 20.11.2014
 * Time: 08:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Microsoft.Win32;
using PiBoost;
using System.IO.IsolatedStorage;

namespace PiBoost{

	public class FolderTreeDeleter
{
    public FolderTreeDeleter()
    {
        userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
    }

    public FolderTreeDeleter(IsolatedStorageFile isolatedStorageFile)
    {
        userStoreForApplication = isolatedStorageFile;
    }

    private IsolatedStorageFile userStoreForApplication;
        
    /// <summary>
    /// Deletes complete folder tree including all sub folders and its content
    /// </summary>
    /// <param name="folderName">Name of the folder to delete</param>
    /// <returns>In case of success true otherwise false</returns>
    public bool DeleteFolderTree(string folderName)
    {
        //Delete folder if it exists
        if (userStoreForApplication.DirectoryExists(folderName))
        {
            recursiveFolderDeletion(folderName);
        }
        else
        {
            throw new ArgumentException("Sorry tmp does not exist!");
        }

        //Checking success
        if (userStoreForApplication.DirectoryExists(folderName))
        {
            //Folder still there? => result = false
            return false; 
        }
        else
        {
            //Folder gone? => result = true
            return true; 
        }
    }

    private void recursiveFolderDeletion(string folderName)
    {
        //Deletion of all files in folder
        deleteAllFilesInFolder(folderName);

        string searchPath = Path.Combine(folderName, "*.*");

        //Deletion of all subfolders in folder (recursive call of this method)
        foreach (string innerFolderName in userStoreForApplication.GetDirectoryNames(searchPath))
        {
            string folderPath = Path.Combine(folderName, innerFolderName);
            recursiveFolderDeletion(folderPath);
        }

        //Deletion of the folder itsself
        userStoreForApplication.DeleteDirectory(folderName);
    }

    private void deleteAllFilesInFolder(string folderName)
    {
            string searchPath = Path.Combine(folderName, "*.*");

            foreach (string innerFileName in userStoreForApplication.GetFileNames(searchPath))
            {
                string filePath = Path.Combine(folderName, innerFileName);
                userStoreForApplication.DeleteFile(filePath);
            }
    }

	}
}