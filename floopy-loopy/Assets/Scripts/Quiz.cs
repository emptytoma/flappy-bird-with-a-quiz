using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI questionField;
    public Button[] buttons;

    public Question[] questions;

    public void OnEnable()
    {
        var question = questions[Random.Range(0, questions.Length)];

        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }

        questionField.text = question.QuestionText;
        
        var rightAnswerButton = buttons[Random.Range(0, buttons.Length)];
        rightAnswerButton.GetComponentInChildren<TextMeshProUGUI>().text = question.RightAnswer;
        rightAnswerButton.onClick.AddListener(gameManager.Recover);

        for (int i = 0; i < question.WrongAnswers.Length; i++)
        {
            int index = Random.Range(0, question.WrongAnswers.Length);
            var temp = question.WrongAnswers[index];
            question.WrongAnswers[index] = question.WrongAnswers[i];
            question.WrongAnswers[i] = temp;
        }

        int questionsCount = 0;
        
        foreach (var button in buttons)
        {
            if (button == rightAnswerButton) continue;
            
            button.GetComponentInChildren<TextMeshProUGUI>().text = question.WrongAnswers[questionsCount];
            button.onClick.AddListener(gameManager.GameOver);
            questionsCount++;
        }
    }
}
