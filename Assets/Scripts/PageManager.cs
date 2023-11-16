using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPage = 0;

    void Start()
    {
        // Make sure only the first page is active at start
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPage);
        }
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            pages[currentPage].SetActive(false);
            currentPage++;
            pages[currentPage].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            pages[currentPage].SetActive(false);
            currentPage--;
            pages[currentPage].SetActive(true);
        }
    }
}
