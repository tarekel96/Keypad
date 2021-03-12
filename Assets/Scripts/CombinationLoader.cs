using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class CombinationLoader
{
    private static string combinationFolderName = "Assets/Text";
    private static string combinationFileName = "combination.txt";
    private static string combinationPath
    {
        get
        {
            return Path.Combine(combinationFolderName, combinationFileName);
        }
    }


    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExists(defaultCombination);
        return ReadCombinationFromFile();
    }
    public static void EnsureFileExists(List<int> defaultCombination)
    {
        if (!File.Exists(combinationPath))
        {
            CreateFile(defaultCombination);
        }
    }
    public static void CreateFile(List<int> defaultCombination)
    {
        EnsureDirectoryExists();

        StreamWriter writer = new StreamWriter(combinationPath);
        foreach(int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry);
        }
        writer.Close();
    }
    public static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        StreamReader reader = new StreamReader(combinationPath);
        string combinationNumber = string.Empty;
        while((combinationNumber = reader.ReadLine()) != null)
        {
            int combinationInteger = int.Parse(combinationNumber);
            combination.Add(combinationInteger);
        }
        return combination;
    }
    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists(combinationFolderName))
            Directory.CreateDirectory(combinationFolderName);
    }
}
