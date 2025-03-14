using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Notebook UI")]
    [SerializeField] private GameObject notebookUI;
    [SerializeField] private TextMeshProUGUI notebookText;

    private List<string> savedNotes = new List<string>(); 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotebook();
        }
    }

    public void ShowNotebookPage(string treeType)
    {
        string newNote = $" {treeType} -" +
            $"" +
            $" Cet arbre semble robuste.";
        if (!savedNotes.Contains(newNote))
        {
            savedNotes.Add(newNote);
        }

        notebookText.text = string.Join("\n\n", savedNotes);
        notebookUI.SetActive(true);
    }

    public void CloseNotebook()
    {
        notebookUI.SetActive(false);
    }

    public void ToggleNotebook()
    {
        notebookUI.SetActive(!notebookUI.activeSelf);
    }
}
