using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Newtonsoft.Json;
using ChatBot_SfB_AI.Models;

namespace ChatBot_SfB_AI.Dialogs
{
    [Serializable]
    public class FAQDialog : IDialog<object>
    {
        public static string json = "";
        public static string convert = "";

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("どのようなことでお困りでしょうか？文章で質問を入力してください。");
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            int i;
            var message = await item;

            json = await CustomQnAMaker.GetResultAsync(message.Text);

            if (json != "failure")
            {
                var result = JsonConvert.DeserializeObject<QnAMakerResults>(json);
                     
                if (result.Answers[0].Score == 0)
                {
                    await ShowNoFAQ(context);
                }
                else
                {
                    await ShowQuestions(context, result);
                }   
            }
            
        }

        private async Task ShowQuestions(IDialogContext context, QnAMakerResults result)
        {
            int i;
            string resultMessage = "以下から選択してください(番号で入力)\n";

          
            for (i = 0; i < result.Answers.Count; i++)
            {
               resultMessage = resultMessage + (i + 1).ToString() + ". " + result.Answers[i].Questions[0] + "\n";
            }
            resultMessage = resultMessage + (i + 1).ToString() + ". 上記のどれでもない\n";
            await context.PostAsync(resultMessage);
              
            context.Wait(ShowAnswer);
            
        }

        private async Task ShowNoFAQ(IDialogContext context)
        {
            await context.PostAsync("質問に対する回答が見つかりませんでした。");
            context.Done<object>(null);

        }

        private async Task ShowAnswer(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            var num = await item;
            var result = JsonConvert.DeserializeObject<QnAMakerResults>(json);

            convert = await ZenkakuConvert.Convert(num.Text);

            if (Int32.Parse(convert) >= 1 && Int32.Parse(convert) <= result.Answers.Count)
            { 
                 await context.PostAsync(result.Answers[Int32.Parse(convert) - 1].Answer.ToString());
                 context.Done<object>(null);
            }
            else if (Int32.Parse(convert) == result.Answers.Count + 1)
            {
                 await context.PostAsync("お役に立てず申し訳ございません。。");
                 context.Done<object>(null);
            }
            else
            {
                 await ShowQuestions(context, result);
            }

        }

    }
}