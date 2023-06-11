using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ModelShark;

public class LevelSelectionManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                levelButtons[i].interactable = false;
                if (levelButtons[i].TryGetComponent<TooltipTrigger>(out TooltipTrigger tooltipTrigger))
                {
                    tooltipTrigger.enabled = false;
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("levelAt", 1);
        }
    }
}
