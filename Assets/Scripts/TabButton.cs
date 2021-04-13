using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TabButton : MonoBehaviour,IPointerClickHandler,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField]
    private TabGroup tabGroup;
    [SerializeField]
    private GameEvent OnWeaponTypeSelected;
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tabGroup == null)
            tabGroup = transform.parent.GetComponent<TabGroup>();
        tabGroup.Subscribe(this);
        
    }

    public void Select()
    {
        if(OnWeaponTypeSelected!=null)
        OnWeaponTypeSelected.Raise();
       
    }

    public void Deselect()
    {
      
    }

    private void OnDestroy()
    {
        tabGroup.UnSubscribe(this);
    }
}
