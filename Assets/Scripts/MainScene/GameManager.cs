using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float savedAutismLevel, savedEnergyLevel, savedMoney;
    public int savedIntelligence, savedCharisma, savedDexterity, savedStrenght, day, maxEnergy, maxAutism;
    public static GameManager instance;
    public GameObject player;
    public Vector3 playerPosition;
    public string currentScene;
    public Text autismText, strText, intText, chaText, dexText, energyText, moneyText, dayText;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        savedEnergyLevel = 100;
        savedAutismLevel = 50;
        maxEnergy = 100;
        maxAutism = 100;

        autismText.text = savedAutismLevel.ToString();
        energyText.text = savedEnergyLevel.ToString();
        strText.text = savedStrenght.ToString();
        intText.text = savedIntelligence.ToString();
        chaText.text = savedCharisma.ToString();
        dexText.text = savedDexterity.ToString();
    }

    private void Update()
    {
        
        
    }

    public void AutismCheck()
    {
        if (savedAutismLevel > 100)
        {
            AutisticOutburst();
        }
    }

    public void AutisticOutburst()
    {
        Debug.Log("Autistic Outburst");
            savedEnergyLevel = 0;
            savedIntelligence = Mathf.Clamp(savedIntelligence - (1 + (int)(0.1f * savedIntelligence)), 0, 100);
            savedStrenght = Mathf.Clamp(savedStrenght - (1 + (int)(0.1f * savedStrenght)), 0, 100);
            savedCharisma = Mathf.Clamp(savedCharisma - (1 + (int)(0.1f * savedCharisma)), 0, 100);
            savedDexterity = Mathf.Clamp(savedDexterity - (1 + (int)(0.1f * savedDexterity)), 0, 100);
            savedAutismLevel = 0;
            strText.text = savedStrenght.ToString();
            intText.text = savedIntelligence.ToString();
            chaText.text = savedCharisma.ToString();
            dexText.text = savedDexterity.ToString();
    }

    public void SetStats(int energyCost, int autismAdded)
    {

        savedAutismLevel += autismAdded;
        savedEnergyLevel -= energyCost;
        if (savedAutismLevel < 0)
        {
            savedAutismLevel = 0;
        }
        AutismCheck();
        energyText.text = savedEnergyLevel.ToString();
        autismText.text = savedAutismLevel.ToString();
    }

    public void SetAttribute(int attributeIndex, int amountToAddOrReduce)
    {
        switch (attributeIndex)
        {
            case 0:
                instance.savedIntelligence += amountToAddOrReduce;
                intText.text = savedIntelligence.ToString();
                break;
            case 1:
                instance.savedCharisma += amountToAddOrReduce;
                chaText.text = savedCharisma.ToString();
                break;
            case 2:
                instance.savedDexterity += amountToAddOrReduce;
                dexText.text = savedDexterity.ToString();
                break;
            case 3:
                instance.savedStrenght += amountToAddOrReduce;
                strText.text = savedStrenght.ToString();
                break;
            default:
                Debug.Log("Invalid index. Indexes are 0 for intelligence, 1 for charisma, 2 for dexterity and 3 for strenght");
                break;
        }
    }
    #region Saving and loading
    public void Save()
    {
        SaveData svm = new SaveData();
        svm.savedAutismLevel = savedAutismLevel;
        svm.savedEnergyLevel = savedEnergyLevel;
        svm.savedIntelligence = savedIntelligence;
        svm.savedCharisma = savedCharisma;
        svm.savedDexterity = savedDexterity;
        svm.savedStrenght = savedStrenght;
        svm.playerPosition = player.transform.position;
        svm.currentScene = SceneManager.GetActiveScene().name;
        svm.savedMoney = savedMoney;
        svm.day = day;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedata.dat");
        bf.Serialize(file, svm);
    }

    public void Load()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/savedata.dat", FileMode.Open);
        SaveData svm = (SaveData)bf.Deserialize(file);
        SceneManager.LoadScene(svm.currentScene);
        savedAutismLevel = svm.savedAutismLevel;
        savedEnergyLevel = svm.savedEnergyLevel;
        savedIntelligence = svm.savedIntelligence;
        savedCharisma = svm.savedCharisma;
        savedDexterity = svm.savedDexterity;
        savedStrenght = svm.savedStrenght;
        savedMoney = svm.savedMoney;
        day = svm.day;
        player.transform.position = svm.playerPosition;
    }
    #endregion
}

public class SaveData : MonoBehaviour
{

    public float savedAutismLevel, savedEnergyLevel, savedMoney;
    public int savedIntelligence, savedCharisma, savedDexterity, savedStrenght, day;
    public Vector3 playerPosition;
    public string currentScene;
}
