using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EndTheGame : MonoBehaviour {


    // Update is called once per frame
    void Update () {

        if (Agents.numberItemsAI + Agents.numberItemsPlayer == 10 || GameObject.Find("Agents").transform.childCount == 0)
        {
            if(Agents.numberItemsAI > Agents.numberItemsPlayer)
                GameObject.Find("GuiText").GetComponent<GUIText>().text = "AI won!";

            else if (Agents.numberItemsAI < Agents.numberItemsPlayer)
                GameObject.Find("GuiText").GetComponent<GUIText>().text = "Player won!";

            else 
                GameObject.Find("GuiText").GetComponent<GUIText>().text = "It's a tie!";

            Application.Quit();
        }
    }
}
