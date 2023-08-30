using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using RicardoBot.Common;

namespace RicardoBot.Dialogs
{
    public class RootDialogs: ComponentDialog
    {
        public RootDialogs()
        {
            var waterfallstep = new WaterfallStep[]
           {
                setInformation,
                ShowOptions,
                ResponseOption

               //ShowData
           };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallstep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        private async Task<DialogTurnResult> setInformation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("!Bienvenido a MusicStore! Guitarras de Alta Calidad", cancellationToken: cancellationToken);
            await Task.Delay(1000);
            return await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions { Prompt = MessageFactory.Text("Escriba 'Mas Informacion' para brindarle sobre nuestros productos") },
                cancellationToken
                );
        }

        //Muestra Opcion-1
        private async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Estas son las marcas y productos que tenemos disponible.", cancellationToken: cancellationToken);
            return await OptionButtonDialog.ShowOptions(stepContext, cancellationToken);
        }

   
        //Recoge la respuesta
        private async Task<DialogTurnResult> ResponseOption(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = stepContext.Context.Activity.Text;
            await stepContext.Context.SendActivityAsync($"Seleccionaste {option}", cancellationToken: cancellationToken);        
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);

        }

    }
}
