using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currentOjective;

    private string firstText = "Talk to your maid";
    private string keyText = "Find the key\nIt is somewhere near you";


    // Start is called before the first frame update
    void Start()
    {
        currentOjective.text = firstText;
    }

    //This is for updating the text showing what is your current objective
    public void UpdateOjective(string newObject)
    {
        currentOjective.text = newObject;
    }

    //This is a shortcut for whenever the objective is to find a key
    public void FindKey()
    {
        currentOjective.text = keyText;
    }


}
