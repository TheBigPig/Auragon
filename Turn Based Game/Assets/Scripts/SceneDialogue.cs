using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneDialogue : MonoBehaviour {
    public Text textfield;
    string currenttext = "";
    bool isrunning = false;
    bool isforcedcomplete = false;
    int dialoguecounter = 1;
    void printchar(char c)
    {
        textfield.text = textfield.text + c;
    }
    void dialoguecall(string passstring)
    {
        isrunning = true;
        StartCoroutine(stringcall(passstring));
    }
    IEnumerator stringcall(string dialogue)
    {
        textfield.text = ""; 
       char[] chardialogue;
       chardialogue = dialogue.ToCharArray();
       for(int x = 0; x < dialogue.Length; x++){
           yield return new WaitForSeconds(.025f);
           printchar(chardialogue[x]);
           if (x == dialogue.Length-1)
           {
               isrunning = false;
           }
           if (isforcedcomplete == true)
           {
               textfield.text = dialogue;
               isforcedcomplete = false;
               isrunning = false;
               break;
               
           }
       }
    }
    // Use this for initialization
    void Start()
    {
        currenttext = "Hello Kevin! sdfsdfhdskfsdfs dkbfjkeusdnvknsd fkugnsdvnsfdvhdxkj vndsfuivdsjkvnudfnvkdsj nvuksnvksdfnvudnku";
        dialoguecall(currenttext);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
        {
        Debug.Log(dialoguecounter);
        if (isrunning == false)
        {
            dialoguecounter++;
            switch (dialoguecounter)
            {
                case 2:
                    currenttext = "Swiggity Swag  sdfsdfhdskfsdfs dkbfjkeusdnvknsd fkugnsdvnsfdvhdxkj vn";
                    dialoguecall(currenttext);
                    break;
                case 3:
                    currenttext = "What's in the bag  sdfsdfhdskfsdfs dkbfjkeusdnvknsd fkugnsdvnsfdvhdxkj vn";
                    dialoguecall(currenttext);
                    break;
                case 4:
                    currenttext = "I'm gay  sdfsdfhdskfsdfs dkbfjkeusdnvknsd fkugnsdvnsfdvhdxkj vn";
                    dialoguecall(currenttext);
                    break;
            }
        }
        else
        {
            isforcedcomplete = true;
        }
    }
	}
}
