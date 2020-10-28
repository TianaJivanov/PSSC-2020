using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateQuestionWorkflow.QuestionText;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyVoteService
    {
        public Task VerifyIfQuestionIsPosted(VerifiedQuestion question)
        {
            //Daca intrebarea nu este postata nu se poate vota
            return Task.CompletedTask;
        }
     }
}