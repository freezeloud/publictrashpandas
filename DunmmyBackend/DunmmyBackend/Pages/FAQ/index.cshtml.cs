using System.Collections.Generic;

namespace DunmmyBackend.Pages.FAQ
{
    public class IndexModel
    {
        public static List<FAQ> questions = new List<FAQ> {
            new FAQ("Jak používat vaši aplikaci?"),
            new FAQ("Co je to upcycling?"),
            new FAQ("Kam patří mobilní telefon?"),
            new FAQ("Jak funguje Remanufacturing?"),
            new FAQ("Jak předcházet odpadům?"),
            new FAQ("Jak třídit hliník?")
        };

        public static FAQ GetQuestion(int i) {
            return questions[i];
        }

        public static List<FAQ> GetQuestions() {
            return questions;
        }
    }

    public class FAQ {
        public string question;
        public string answer = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas sollicitudin. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Nullam eget nisl. Curabitur sagittis hendrerit ante. Etiam dictum tincidunt diam. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Aenean vel massa quis mauris vehicula lacinia.";

        public FAQ(string q) {
            this.question = q;
        }
    }
}