using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiarySystem : MonoBehaviour
{
     [SerializeField] private TMP_Text text;
     [SerializeField] private GameObject diaryImage;
     [SerializeField] private GameObject textDiaryParent;
    
     [SerializeField] private string diaryWords;
    // Start is called before the first frame update
    void Start()
    {
        diaryImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiarySys(){
        
        Instantiate(text,textDiaryParent.transform);
        text.SetText(diaryWords);
    }
}
