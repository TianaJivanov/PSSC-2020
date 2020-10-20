 using Profile.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static Profile.Domain.CreateQuestionWorkflow.CreateQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var tag = "c#".Split(',').ToList();
            var cmd = new CreateQuestionCmd("Does dontDestroyOnLoad only work a single time?", "Can someone give me concrete details?", tag);
            var result = CreateQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
           

        private static ICreateQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotPostedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotPostedResult.Reason}");
            return questionNotPostedResult;
        }

        private static ICreateQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            Console.WriteLine($"Question: {question.Title}");
            return question;
        }

        public static ICreateQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if (string.IsNullOrEmpty(createQuestionCommand.Title))
            {
                var errors = new List<string>() { "Question title invalid" };
                return new QuestionValidationFailed(errors);
            }

            if (string.IsNullOrEmpty(createQuestionCommand.Body))
            {
                var errors = new List<string>() { "Question body invalid" };
                return new QuestionValidationFailed(errors);
            }

            if (createQuestionCommand.Tags.Count==0)
            {
                var errors = new List<string>() { "Question tag invalid" };
                return new QuestionValidationFailed(errors);
            }


            //if (new Random().Next(10) > 1)
            //{
            //    return new QuestionNotPosted("Title could not be verified");
            //}

            var result = new QuestionPosted(createQuestionCommand.Title);
            return result;
        }
    }
}
