using System;

[Serializable]
public struct Question
{
    public string QuestionText;
    public string RightAnswer;
    public string[] WrongAnswers;
}