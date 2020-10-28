using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.QuestionText;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyQuestionService
    {
        public Result<VerifiedQuestion> VerifyQuestion(UnverifiedQuestion question)
        {
            //Intrebarea se va publica doar daca se respecta conditia de 1000 caractere si conditia de taguri (intre 1 si 3) 
            return new VerifiedQuestion(question.Question,question.Tags);
        }
    }
}
