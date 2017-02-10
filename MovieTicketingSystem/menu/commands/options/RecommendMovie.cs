//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.movie;
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTicketingSystem.menu.commands.options {
    class RecommendMovie:Command {

        private OptionAttempt attempt;
        private static Dictionary<String, Member> credentials = new Dictionary<String, Member>();
        private Dictionary<Movie, int> moviePoints;
        private List<Movie> safeForUser;
        private Member member;
        private Dictionary<MovieGenre, int> numberOfTimesCalled;

        // Option 8
        public RecommendMovie() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 8. Recommend movies");

            this.attempt = attempt;
            moviePoints = new Dictionary<Movie, int>();
            safeForUser = new List<Movie>();
            member = null;
            numberOfTimesCalled = new Dictionary<MovieGenre, int>();

            bool newUser = !Login();
            LoadData();
            if(newUser) GetUserPreference();
            SortMovies();
            PrintRecommendation();
        }

        private void LoadData() {
            // Loads appropriate movies based on users age
            foreach(Movie movie in Program.movieList) {
                if(GetAppropriateClassification(member.Birthday).Contains(movie.Classification))
                    safeForUser.Add(movie);
            }
        }

        private void GetUserPreference() {
            Random random = new Random();
            Movie movie1 = null;
            Movie movie2 = null;
            int option = 0;
            Console.WriteLine("\nWe want to know you better!");

            foreach(MovieGenre genre in Enum.GetValues(typeof(MovieGenre)))
                numberOfTimesCalled.Add(genre, 1);

            for(int i = 1; i <= Program.NO_MOVIE_ASKED; i++) {
                movie1 = safeForUser[random.Next(0, safeForUser.Count)];
                for(int j = 0; j < 3; j++) {
                    movie2 = safeForUser[random.Next(0, safeForUser.Count)];
                    if(movie1 != movie2) break;
                }

                attempt.Run(() => {
                    Console.WriteLine("\nTell us which movie you would prefer to watch! [" + i + "/" +
                    Program.NO_MOVIE_ASKED + "]");
                    Console.WriteLine("1) " + movie1.Title);
                    Console.WriteLine("2) " + movie2.Title);
                    Console.WriteLine("3) I don't know");

                    Console.Write("Enter your option: ");
                    option = Utility.TryConvertingStringToInt(Console.ReadLine());
                    if(option == 1 || option == 2 || option == 3)
                        return true;
                    return false;
                });

                switch(option) {
                    case 1:
                        SetUserPreference(movie1);
                        break;
                    case 2:
                        SetUserPreference(movie2);
                        break;
                    default:
                        break;
                }
            }

            // To ensure fairness
            foreach(MovieGenre genre in Enum.GetValues(typeof(MovieGenre)))
                member.GenreLikings[genre] /= numberOfTimesCalled[genre];
        }

        private void SetUserPreference(Movie movie) {
            foreach(MovieGenre genre in movie.GenreList) {
                member.GenreLikings[genre] += 100;
                numberOfTimesCalled[genre]++;
            }
        }

        private bool Login() {
            Console.Write("\nPlease enter your name: ");
            String name = Console.ReadLine();

            if(!credentials.TryGetValue(name, out member)) {
                // User not created
                credentials.Add(name, new Member(name, GetBirthday()));
                credentials.TryGetValue(name, out member);
                return false;
            }
            return true;
        }

        private DateTime GetBirthday() {
            return (DateTime) attempt.Run(() => {
                Console.Write("Enter your birthday [eg.DD/MM/YYYY]: ");
                return Utility.TryConvertingStringToDateTime(Console.ReadLine());
            },
            obj => {
                return (DateTime) obj < DateTime.Now;
            });
        }

        private List<String> GetAppropriateClassification(DateTime birthday) {
            int age = DateTime.Today.Year - birthday.Year;
            List<String> list = new List<String>();

            list.Add(MovieClassification.G.ToString());
            if(age >= 13) list.Add(MovieClassification.PG13.ToString());
            if(age >= 16) list.Add(MovieClassification.NC16.ToString());
            if(age >= 18) list.Add(MovieClassification.M18.ToString());
            if(age >= 21) list.Add(MovieClassification.R21.ToString());

            return list;
        }

        private void SortMovies() {
            int genrePoints;
            int ratingPoints;
            foreach(Movie movie in safeForUser) {
                genrePoints = 0;
                foreach(MovieGenre genre in movie.GenreList)
                    genrePoints += member.GenreLikings[genre];
                genrePoints /= movie.GenreList.Count;
                genrePoints *= (100 - Program.RATING_MODIFIER);

                ratingPoints = (int)Select.MovieRating(movie) * Program.RATING_MODIFIER;

                moviePoints.Add(movie, genrePoints + ratingPoints);
            }
        }

        private void PrintRecommendation() {
            Console.WriteLine("\nWe recommend you the follow movies to watch:");
            int count = 0;
            Console.WriteLine(String.Format("{0,-5} {1,-30} {2, -20}", "No", "Title", "Score Calculated"));
            foreach(var item in moviePoints.OrderByDescending(r => r.Value).Take(3)) {
                count++;
                Console.WriteLine(String.Format("{0,-5} {1,-30} {2, -20}", count, item.Key.Title, item.Value));
            }
        }

    }
}
