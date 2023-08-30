using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RicardoBot.Common
{
    public class OptionButtonDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions
                {
                    Prompt = CreateCarousel()
                },
                cancellationToken
               );
            return option;

        }

        private static Activity CreateCarousel()
        {
            //return MessageFactory.Attachment(heroCard.ToAttachment()) as Activity;
            var heroCard1 = new HeroCard
            {
                Title = "Martin & Go EST. 1833",
                Subtitle = "Modelos en Stock.",
                Images = new List<CardImage> { new CardImage("https://scontent.flim9-1.fna.fbcdn.net/v/t1.6435-9/47381813_2185553654828756_4820663390290575360_n.jpg?_nc_cat=109&ccb=1-5&_nc_sid=730e14&_nc_eui2=AeFEij2FgM_PI44BeYVmGgsD0Ifce0-JdBTQh9x7T4l0FB12gZZ5XcnF8fdefBszzPOVcegia-UD9mlSMTMjuQVt&_nc_ohc=z2ytBqYaJCMAX_-rPE9&_nc_ht=scontent.flim9-1.fna&oh=00_AT9Mpp6gCLhbgsVZW2Wgz5Ogr9LGxzCobdKXrdag8gX8QA&oe=624D23F7") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title="DM-35", Value="Martin & Go EST. 1833 Modelo: DM-35", Type= ActionTypes.ImBack},
                    new CardAction(){Title="DX2-E", Value="Martin & Go EST. 1833D Modelo: X2-E", Type= ActionTypes.ImBack},
                    new CardAction(){Title="HD-28", Value="Martin & Go EST. 1833 Modelo: HD-28", Type= ActionTypes.ImBack},
                    new CardAction(){Title="DR-52", Value="Martin & Go EST. 1833 Modelo: DR-52", Type= ActionTypes.ImBack},
                    new CardAction(){Title="Más modelos Martin & Go", Value="https://www.martinguitar.com/guitars/", Type= ActionTypes.OpenUrl},

                },
            };
            var heroCard2 = new HeroCard
            {
                Title = "YAMAHA ©",
                Subtitle = "Modelos en Stock.",
                Images = new List<CardImage> { new CardImage("https://www.samash.com/media/catalog/product/y/g/ygigdlxxx-p_1.jpg?quality=80&bg-color=255,255,255&fit=bounds&height=1200&width=1200&canvas=1200:1200") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title="FG-800", Value="YAMAHA © Modelo: FG-800", Type= ActionTypes.ImBack},
                    new CardAction(){Title="CSF3M", Value="YAMAHA © Modelo: CSF3M", Type= ActionTypes.ImBack},
                    new CardAction(){Title="A5R A.R.E", Value="YAMAHA © Modelo: A5R A.R.E", Type= ActionTypes.ImBack},
                    new CardAction(){Title="FG5 Red Label", Value="YAMAHA © Modelo: FG5 Red Label", Type= ActionTypes.ImBack},
                    new CardAction(){Title="Más modelos YAMAHA ©", Value="https://mx.yamaha.com/es/products/musical_instruments/guitars_basses/", Type= ActionTypes.OpenUrl},
                },
            };
            var heroCard3 = new HeroCard
            {
                Title = "Taylor Guitars",
                Subtitle = "Modelos en Stock.",
                Images = new List<CardImage> { new CardImage("https://m.media-amazon.com/images/I/81bqHH+1jFL._AC_SX425_.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title="Baby", Value="Taylor Guitars Modelo: Baby", Type= ActionTypes.ImBack},
                    new CardAction(){Title="GS Mini", Value="Taylor Guitars Modelo: GS Mini", Type= ActionTypes.ImBack},
                    new CardAction(){Title="Grand Auditorium", Value="Taylor Gutiars Modelo: Grand Auditorium", Type= ActionTypes.ImBack},
                    new CardAction(){Title="Dreadnought", Value="Taylor Gutiars Modelo: Dreadnought", Type= ActionTypes.ImBack},
                    new CardAction(){Title="Más modelos Taylor Guitars", Value="https://www.taylorguitars.com/guitars/acoustic", Type= ActionTypes.OpenUrl},
                },
            };
            var optionAttachments = new List<Attachment>()
            {
                heroCard1.ToAttachment(),
                heroCard2.ToAttachment(),
                heroCard3.ToAttachment()
            };
            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}