using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent userDataRefreshed;
    [SerializeField]
    private GameObject scrollUp;
    [SerializeField]
    private GameObject scrollDown;
    [SerializeField]
    private Scrollbar vertScrollBar;

    [Header("Weapon Data")]
    [SerializeField]
    private TextMeshProUGUI weaponName;
    [SerializeField]
    private TextMeshProUGUI weaponDesc;
    [SerializeField]
    private Transform weaponHolder;
    [SerializeField]
    private Image weaponWireframe;
    [SerializeField]
    private Sprite InfoIcon;

    [Header("User Data")]
    [SerializeField]
    private TextMeshProUGUI userName;
    [SerializeField]
    private TextMeshProUGUI userCurrency;
    [SerializeField]
    private TextMeshProUGUI userCoins;

    [Header("Transform parents")]
    [SerializeField]
    private Transform weightBarsParent;
    [SerializeField]
    private Transform accuracyBarParent;
    [SerializeField]
    private Transform rangeBarParent;
    [SerializeField]
    private Transform damageBarParent;
    [SerializeField]
    private Transform fireRateBarParent;
    [SerializeField]
    private Transform menuOptParent;
   

    [Header("Prefabs")]
    [SerializeField]
    private GameObject propertyBarPrefab;
    [SerializeField]
    private GameObject menuOptPrefab;

    


    private GameObject weaponprefab;

    private void Start()
    {
        InitializeProperties();
        userDataRefreshed.Raise();
        scrollUp.GetComponent<Button>().onClick.AddListener(MenuUpScroll);
        scrollDown.GetComponent<Button>().onClick.AddListener(MenuDownScroll);

    }
    public void ClearMenuOption()
    {
        foreach(Transform child in menuOptParent)
        {
            Destroy(child.gameObject);
        }
        scrollUp.SetActive(false);
        scrollDown.SetActive(false);

    }

    public void UpdateMenu(WeaponData weaponData)
    {
        GameObject obj=Instantiate(menuOptPrefab, menuOptParent);
        obj.GetComponent<Image>().sprite = InfoIcon;
        obj.transform.GetChild(0).GetComponent<Image>().sprite = weaponData.Icon;
        obj.transform.GetComponentInChildren<TextMeshProUGUI>().text = weaponData.WeaponName;
        obj.GetComponent<Button>().onClick.AddListener(delegate { UpdateDisplayUI(weaponData); });
        scrollUp.SetActive(true);
        scrollDown.SetActive(true);
        //obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    public void UpdateDisplayUI(WeaponData weaponData)
    {
        if (weaponprefab != null)
            Destroy(weaponprefab);

        SetProperties(false);
        weaponName.text = weaponData.WeaponName;
        weaponDesc.text = weaponData.Description;

         weaponprefab = weaponData.Prefab;
        weaponprefab.SetActive(true);
        weaponprefab.transform.SetParent(weaponHolder);
        //weaponprefab.transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0f, 0f, 0f));
        weaponWireframe.sprite = weaponData.Wireframe;

        SetProperties(true,weaponData.Weight,weaponData.Accuracy,weaponData.Range,weaponData.Damage,weaponData.FireRate);
        weaponprefab.transform.localPosition = Vector3.zero;

       

    }

    public void MenuUpScroll()
    {
        int totalChildren = menuOptParent.transform.childCount;
        float step = menuOptParent.GetComponent<RectTransform>().rect.height / totalChildren;
        vertScrollBar.value +=  step;
        Debug.Log("mnu opt new position" + menuOptParent.transform.position);
    }
    public void MenuDownScroll()
    {
        int totalChildren = menuOptParent.transform.childCount;
        float step = menuOptParent.GetComponent<RectTransform>().rect.height / totalChildren;
        vertScrollBar.value -= step;
        Debug.Log("mnu opt new position" + menuOptParent.transform.position);

    }
    public void UpdateUserData(UserData userData)
    {
        userName.text = userData.UserName;
        userCoins.text = userData.Coins.ToString();
        userCurrency.text = userData.Currency.ToString();
    }
    void InitializeProperties()
    {
       
        for (int i = 0; i < 10; i++)
        {
            GameObject bar = Instantiate(propertyBarPrefab, weightBarsParent);
            bar.transform.localPosition = Vector3.zero;
            bar.SetActive(false);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject bar = Instantiate(propertyBarPrefab, accuracyBarParent);
            bar.transform.localPosition = Vector3.zero;
            bar.SetActive(false);

        }
        for (int i = 0; i < 10; i++)
        {
            GameObject bar = Instantiate(propertyBarPrefab, fireRateBarParent);
            bar.transform.localPosition = Vector3.zero;
            bar.SetActive(false);

        }
        for (int i = 0; i < 10; i++)
        {
            GameObject bar = Instantiate(propertyBarPrefab, damageBarParent);
            bar.transform.localPosition = Vector3.zero;
            bar.SetActive(false);

        }
        for (int i = 0; i < 10; i++)
        {
            GameObject bar = Instantiate(propertyBarPrefab, rangeBarParent);
            bar.transform.localPosition = Vector3.zero;
            bar.SetActive(false);

        }
    }

    void SetProperties(bool setTo,int weightBars=10, int accBars=10,int rangeBars=10,int damageBars=10,int firerateBars=10)
    {
        for(int i=0;i<weightBars;i++)
        {
            weightBarsParent.GetChild(i).gameObject.SetActive(setTo);
        }

        for (int i = 0; i < accBars; i++)
        {
            accuracyBarParent.GetChild(i).gameObject.SetActive(setTo);
        }

        for (int i = 0; i < rangeBars; i++)
        {
            rangeBarParent.GetChild(i).gameObject.SetActive(setTo);
        }

        for (int i = 0; i < damageBars; i++)
        {
            damageBarParent.GetChild(i).gameObject.SetActive(setTo);
        }

        for (int i = 0; i < firerateBars; i++)
        {
            fireRateBarParent.GetChild(i).gameObject.SetActive(setTo);
        }


    }
    




}
