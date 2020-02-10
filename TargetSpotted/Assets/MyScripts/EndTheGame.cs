using System.Collections;
using UnityEngine.UI;
using UnityEngine;

//Check if it is the end of game and display winner
public class EndTheGame : MonoBehaviour {

    [SerializeField]
    public GameObject agent1;
    [SerializeField]
    public GameObject agent2;

    private AI ai;
    private Player player;

    public void Start()
    {
        player = agent1.GetComponent<Player>();
        ai = agent2.GetComponent<AI>();
    }


    // Update is called once per frame
    void Update ()
    {
        CheckIfEndOfGame();
    }

    //Check if it is the end of the game
    public void CheckIfEndOfGame()
    {
        if (GameObject.Find("Agents").transform.childCount == 0 || ai.GetNumberItems() + player.GetNumberItems() == 10)
        {
            DisplayEndMessage();
        }
    }

    //Display an ending message
    public void DisplayEndMessage()
    {
        if (ai.GetNumberItems() > player.GetNumberItems())
            DisplayAIWon();

        else if (player.GetNumberItems() < ai.GetNumberItems())
            DisplayPlayerWon();

        else if (player.GetNumberItems() == ai.GetNumberItems())
            DisplayTieMessage();

        else
            Debug.LogError("Error at end of game");

        Application.Quit();
    }

    //Display message
    public void DisplayTieMessage()
    {
        GameObject.Find("GuiText").GetComponent<GUIText>().text = "It's a tie!";
    }

    //Display a message
    public void DisplayPlayerWon()
    {
        GameObject.Find("GuiText").GetComponent<GUIText>().text = "Player won!";
    }

    //Display a message
    public void DisplayAIWon()
    {
        GameObject.Find("GuiText").GetComponent<GUIText>().text = "AI won!";
    }
}
