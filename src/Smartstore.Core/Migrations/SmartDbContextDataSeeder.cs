using Smartstore.Data.Migrations;

namespace Smartstore.Core.Data.Migrations
{
    public class SmartDbContextDataSeeder : IDataSeeder<SmartDbContext>
    {
        public DataSeederStage Stage => DataSeederStage.Early;
        public bool AbortOnFailure => false;

        public async Task SeedAsync(SmartDbContext context, CancellationToken cancelToken = default)
        {
            await context.MigrateLocaleResourcesAsync(MigrateLocaleResources);
            await MigrateSettingsAsync(context, cancelToken);
        }

        public Task MigrateSettingsAsync(SmartDbContext context, CancellationToken cancelToken = default)
        {
            return Task.CompletedTask;
        }

        public void MigrateLocaleResources(LocaleResourcesBuilder builder)
        {
            builder.AddOrUpdate("Aria.Label.MainNavigation", "Main navigation", "Hauptnavigation");
            builder.AddOrUpdate("Aria.Label.PageNavigation", "Page navigation", "Seitennavigation");
            builder.AddOrUpdate("Aria.Label.OffCanvasMenuTab", "Shop sections", "Shop-Bereiche");
            builder.AddOrUpdate("Aria.Label.ShowPreviousProducts", "Show previous product group", "Vorherige Produktgruppe anzeigen");
            builder.AddOrUpdate("Aria.Label.ShowNextProducts", "Show next product group", "N�chste Produktgruppe anzeigen");
            builder.AddOrUpdate("Aria.Label.CommentForm", "Comment form", "Kommentarformular");

            // TODO: (wcag) (mg) Not used anywhere? I couldn't find these resources.
            builder.AddOrUpdate("Aria.Label.SearchFilters", "Search filters", "Suchfilter");
            builder.AddOrUpdate("Aria.Label.SelectAllListEntries", "Select or deselect all entries in the list", "Alle Eintr�ge der Liste aus- oder abw�hlen");

            builder.AddOrUpdate("Aria.Description.SearchBox",
                "Enter a search term. Press the Enter key to view all the results.",
                "Geben Sie einen Suchbegriff ein. Dr�cken Sie die Eingabetaste, um alle Ergebnisse aufzurufen.");
            builder.AddOrUpdate("Aria.Description.InstantSearch",
                "Enter a search term. Results will appear automatically as you type. Press the Enter key to view all the results.",
                "Geben Sie einen Suchbegriff ein. W�hrend Sie tippen, erscheinen automatisch erste Ergebnisse. Dr�cken Sie die Eingabetaste, um alle Ergebnisse aufzurufen.");
            builder.AddOrUpdate("Aria.Description.AutoSearchBox",
                "Enter a search term. Results will appear automatically as you type.",
                "Geben Sie einen Suchbegriff ein. Die Ergebnisse erscheinen automatisch, w�hrend Sie tippen.");

            builder.AddOrUpdate("Aria.ScreenReaderOnly.CurrencySelector", "Current currency {0} - Change currency", "Aktuelle W�hrung {0} � W�hrung wechseln");
            builder.AddOrUpdate("Aria.ScreenReaderOnly.LanguageSelector", "Current language {0} - Change language", "Aktuelle Sprache {0} � Sprache wechseln");

            builder.AddOrUpdate("Search.SearchBox.Clear", "Clear search term", "Suchbegriff l�schen");
            builder.AddOrUpdate("Common.ScrollUp", "Scroll up", "Nach oben scrollen");
            builder.AddOrUpdate("Common.SelectAction", "Select action", "Aktion w�hlen");

            builder.AddOrUpdate("Admin.Configuration.Settings.General.Common.Captcha.Hint",
                "CAPTCHAs are used for security purposes to help distinguish between human and machine users. They are typically used to verify that internet forms are being"
                + " filled out by humans and not robots (bots), which are often misused for this purpose. reCAPTCHA accounts are created at <a"
                + " class=\"alert-link\" href=\"https://cloud.google.com/security/products/recaptcha?hl=en\" target=\"_blank\">Google</a>. Select <b>Task (v2)</b> as the reCAPTCHA type.",
                "CAPTCHAs dienen der Sicherheit, indem sie dabei helfen, zu unterscheiden, ob ein Nutzer ein Mensch oder eine Maschine ist. In der Regel wird diese Funktion genutzt,"
                + " um zu �berpr�fen, ob Internetformulare von Menschen oder Roboter (Bots) ausgef�llt werden, da Bots hier oft missbr�uchlich eingesetzt werden."
                + " reCAPTCHA-Konten werden bei <a class=\"alert-link\" href=\"https://cloud.google.com/security/products/recaptcha?hl=de\" target=\"_blank\">Google</a>"
                + " angelegt. W�hlen Sie als reCAPTCHA-Typ <b>Aufgabe (v2)</b> aus.");

            builder.AddOrUpdate("Polls.TotalVotes", "{0} votes cast.", "{0} abgegebene Stimmen.");

            builder.AddOrUpdate("Blog.RSS.Hint",
                "Opens the RSS feed with the latest blog posts. Subscribe with an RSS reader to stay informed.",
                "�ffnet den RSS-Feed mit aktuellen Blogbeitr�gen. Mit einem RSS-Reader abonnieren und informiert bleiben.");

            builder.AddOrUpdate("News.RSS.Hint",
                "Opens the RSS feed with the latest news. Subscribe with an RSS reader to stay informed.",
                "�ffnet den RSS-Feed mit aktuellen News. Mit einem RSS-Reader abonnieren und informiert bleiben.");

            builder.AddOrUpdate("Order.CannotCompleteUnpaidOrder",
                "An order with a payment status of \"{0}\" cannot be completed.",
                "Ein Auftrag mit dem Zahlungsstatus \"{0}\" kann nicht abgeschlossen werden.");
        }
    }
}