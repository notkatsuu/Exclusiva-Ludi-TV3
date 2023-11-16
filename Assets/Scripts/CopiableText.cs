using UnityEngine;
using UnityEngine.UI;

public class CopyToClipboard : MonoBehaviour
{
    public Text textToCopy;

    // Attach this method to the Button's onClick event in the Inspector
    public void CopyText()
    {
        TextEditor editor = new TextEditor();
        editor.text = textToCopy.text;
        editor.SelectAll();
        editor.Copy();
    }

}

