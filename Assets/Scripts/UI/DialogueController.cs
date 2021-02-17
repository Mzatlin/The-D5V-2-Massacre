using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueController : MonoBehaviour, IEndDialogue
{
    public Canvas dialogueCanvas;
    public PlayerStateSO playerState;
    public TextMeshProUGUI textDialogue;
    public DialogueWriterSO dialoguewriter;
    [TextArea(2,3)]
    public string content;
    [SerializeField]
    float typingSpeed = 0.3f;
    bool isActive = false;
    IEnumerator dialogueCoroutine = null;
    public event Action OnEndDialogue = delegate { };


    IActivateDialogue Activate => GetComponent<IActivateDialogue>();

    // Start is called before the first frame update
    void Awake()
    {
        if(dialoguewriter == null)
        {
            Debug.Log(gameObject.name + " has a dialoguecontroller without the dialogueSO!");
        }

        if(dialogueCanvas != null && textDialogue != null)
        {
            dialogueCanvas.enabled = false;
            textDialogue.text = "";
        }
        else
        {
            Debug.Log("Dialogue Canvas/Text Dialogue not attached to: " + gameObject);
        }

        if(Activate != null)
        {
            Activate.OnActivateDialogue += HandleActivateDialogue;
        }
    }

   void OnDestroy()
    {
        if (Activate != null)
        {
            Activate.OnActivateDialogue -= HandleActivateDialogue;
        }
        if(dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }
    }


    public void SetContentText(string _content)
    {
        content = _content;
    }


    void HandleActivateDialogue()
    {
        if (dialogueCanvas != null && !dialoguewriter.IsWriting)
        {
            dialogueCanvas.enabled = true;
            isActive = true;
            dialoguewriter.RequestToWrite();
            dialogueCoroutine = TypeDelay(content);
            StartCoroutine(dialogueCoroutine);
        }
    }

    IEnumerator TypeDelay(string sentence)
    {
        var newtypingSpeed = typingSpeed / 10;
        foreach(char letter in sentence)
        {
            textDialogue.text += letter;
            yield return new WaitForSeconds(newtypingSpeed);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            EndDialogueOnInput();
        }
    }

    void EndDialogueOnInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerState != null && !playerState.isPaused)
        {
            if (IsTextFinished())
            {
                OnEndDialogue();
                dialogueCanvas.enabled = false;
                textDialogue.text = "";
                isActive = false;
                dialoguewriter.ResetWriter();
            }
            else
            {
                StopCoroutine(dialogueCoroutine);
                textDialogue.text = content;
            }
           
        }

    }

    bool IsTextFinished()
    {
        if(textDialogue.text == content)
        {
            return true;
        }
        return false;
    }

}
