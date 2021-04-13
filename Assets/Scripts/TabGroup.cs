using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TabGroup : MonoBehaviour
{
    [SerializeField]
    private List<TabButton> tabButtons;
    [SerializeField]
    private Sprite idleImg;
    [SerializeField]
    private Sprite selectedImg;

    private TabButton selectedTab;
   


    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
           
        }

        tabButtons.Add(button);

        if (tabButtons.Count == transform.childCount)
            OnAllButtonsAdded();

    }

    public void UnSubscribe(TabButton button)
    {
        if(tabButtons!=null)
        tabButtons.Remove(button);
    }

    void OnAllButtonsAdded()
    {
        tabButtons=tabButtons.OrderBy(go => go.transform.GetSiblingIndex()).ToList();
       // OnTabSelected(tabButtons[0]);
    }

    public void OnTabEnter(TabButton button)
    {
      
    }

    public void OnTabExit(TabButton button)
    {
       
    }

    public void OnTabSelected(TabButton button)
    {
        Debug.Log(button.name);
        ResetButtons();

        if (selectedTab != null)
        {
            Debug.Log("deselcting selected tab");
            selectedTab.Deselect();
            button.GetComponent<Image>().sprite = idleImg;

        }
        selectedTab = button;
        button.Select();
        button.GetComponent<Image>().sprite = selectedImg;


    }

    public void ResetButtons()
    {
        foreach(TabButton button in tabButtons)
        {
            button.Deselect();
            button.GetComponent<Image>().sprite = idleImg;

        }
    }
}
