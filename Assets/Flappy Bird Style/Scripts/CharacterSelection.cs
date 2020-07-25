using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    public Text[] charNames;
    private int index;

    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
            go.SetActive(false);

        foreach (Text go in charNames)
            go.enabled = false;

        if (characterList[index])
        {
            characterList[index].SetActive(true);
            charNames[index].enabled = true;
        }
    }

    public void ToggleLeft()
    {
        AudioManager.instance.PlayClickSound();
        characterList[index].SetActive(false);
        charNames[index].enabled = false;

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        characterList[index].SetActive(true);
        charNames[index].enabled = true;
    }

    public void ToggleRight()
    {
        AudioManager.instance.PlayClickSound();
        characterList[index].SetActive(false);
        charNames[index].enabled = false;

        index++;
        if (index == characterList.Length)
            index = 0;

        characterList[index].SetActive(true);
        charNames[index].enabled = true;
    }

    public void ConfirmButton()
    {
        AudioManager.instance.PlayClickSound();
        PlayerPrefs.SetInt("CharacterSelected", index);
    }



}
