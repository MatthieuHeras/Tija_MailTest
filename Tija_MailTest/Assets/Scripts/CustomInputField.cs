using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class CustomInputField : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI placeholder = default;
        [SerializeField] private TextMeshProUGUI text = default;

        public event Action OnCompletion = delegate {  };

        private string currentText = "";
        private string currentWord = "";
        private string newWord = "";
        
        private bool isActivated = false;

        private void Update()
        {
            if (!isActivated)
                return;

            string input = Input.inputString;
            input = WordDatabase.FilterString(input);
            
            if (input == "")
                return;
            
            currentWord += input;

            if (currentWord.Length > newWord.Length)
                currentWord = currentWord.Substring(0, newWord.Length);

            if (currentWord.Length == newWord.Length)
                CompleteWord();
            
            RefreshText();
            RefreshPlaceholder();
        }

        public void AddWord(string word)
        {
            newWord = word;
            RefreshPlaceholder();
        }

        public void Activate()
        {
            isActivated = true;
        }

        private void RefreshText()
        {
            text.text = currentText + currentWord;
        }

        private void RefreshPlaceholder()
        {
            placeholder.text = currentText + currentWord + newWord.Substring(currentWord.Length);
        }

        private void CompleteWord()
        {
            currentText += currentWord + " ";
            currentWord = "";
            newWord = "";
            OnCompletion();
        }
    }
}
