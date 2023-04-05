using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Dialog dialog;
    private int dialogNumber;

    //public GameObject startDialogButton;
    public GameObject dialogWindow;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Image photoOfNPC;

    public LayerMask dialogLayer;

    private bool isDialoging = false;
    private bool isTriggered = false;

    public bool deleteAfter = false;
    void Start()
    {
        dialogLayer = LayerMask.NameToLayer("Ignore Raycast");
        dialog = GetComponent<Dialog>();

        //startDialogButton.SetActive(false);
        dialogWindow.SetActive(false);
    }

    void Update()
    {
        if (isTriggered)
        {
            //if (isDialoging)
            //{
            //    startDialogButton.SetActive(false);
            //}
            //else
            //{
            //    startDialogButton.SetActive(true);
            //}

            if (!isDialoging)
            {
                //startDialogButton.SetActive(false);
                isDialoging = true;
                dialogNumber = 0;
                photoOfNPC.sprite = dialog.photoOfCharacter;
                nameText.text = dialog.nameOfChatacter;
                dialogText.text = dialog.dialogs[dialogNumber];
                dialogWindow.SetActive(true);
            }
            
                if (Input.GetKeyDown(KeyCode.E) && isDialoging)
            {
                Debug.Log(dialogNumber);
                NextDialog();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Walking>().isMovable = false;
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            EndDialog();
        }
    }

    private void NextDialog()
    {
        if (dialogNumber < dialog.dialogs.Length)
        {
            Debug.Log(dialogNumber);
            dialogText.text = dialog.dialogs[dialogNumber ++];
            Debug.Log(dialogNumber);
        }
        else
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {

        FindObjectOfType<Walking>().isMovable = true;
        dialogWindow.SetActive(false);
        isDialoging = false;
        isTriggered = false;
        //startDialogButton.SetActive(true);
        dialogNumber = 0;
        if (deleteAfter) Destroy(gameObject);
    }
}