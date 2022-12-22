using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordObject : MonoBehaviour
{
    //properties
    [SerializeField]
    private string word;
    [SerializeField]
    private string[] syllables;


    public string getWord()
    {
        return word;
    }

    public int getNumberWords()
    {
        return word.Length;
    }

    public string[] getSyllables()
    {
        return syllables;
    }

    public int getNumberSyllables()
    {
        return syllables.Length;
    }

    public bool hitWord(string[] attempt)
    {
        string wordAttempt = "";

        foreach(string letter in attempt)
        {
            wordAttempt += letter;
        }

        if (string.Compare(word, wordAttempt) == 0)
            return true;
        else
            return false;
    }

    public int getRandomLetter()
    {
        return Random.Range(0, getNumberWords());
    }
}
