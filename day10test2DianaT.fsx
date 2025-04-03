//CSD215 TEST2
//03-04-2025
(*You will write a program that creates and processes a list of Oscar movies using concepts such as records, discriminated unions, filter, and map. *)
printfn "TEST 2. Program 1. An F# program that creates and processes a list of Oscar movies using concepts such as records, discriminated unions, filter, and map."

(*A. Define the model.
Define a genre called "discriminated union."
The discriminated union genre has the following cases: Horror, Drama, Thriller, Comedy, Fantasy, and Sport.*)
// discriminated union for Genre
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

(*Define the "Director" record type.
The "Director" record has the following fields:
Name: director's name, of type String
Movies: total number of movies, of type int*)
type Director = {
    Name: string
    Movies: int
}

(*Define the "Movie" record type.
The movie record has the following cases:
Name: movie name, of type String
Run length: running time of the movie in minutes, of type int
Genre: discriminated union representing the genre, of type genre
Director: represents the director, of type Director
IMDB Rating: rating of the movie on IMDB, of type float*)
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

(*Create movie instances.
Create and populate movie instances according to the table provided.*)
let director1 = { Name = "Sian Heder"; Movies = 9 }
let director2 = { Name = "Kenneth Branagh"; Movies = 23 }
let director3 = { Name = "Adam McKay"; Movies = 27 }
let director4 = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
let director5 = { Name = "Denis Villeneuve"; Movies = 24 }
let director6 = { Name = "Reinaldo Marcus Green"; Movies = 15 }
let director7 = { Name = "Paul Thomas Anderson"; Movies = 49 }
let director8 = { Name = "Guillermo Del Toro"; Movies = 22 }

let movie1 = { Name = "CODA"; RunLength = 111; Genre = Drama; Director = director1; IMDBRating = 8.1 }
let movie2 = { Name = "Belfast"; RunLength = 98; Genre = Comedy; Director = director2; IMDBRating = 7.3 }
let movie3 = { Name = "Don't Look Up"; RunLength = 138; Genre = Comedy; Director = director3; IMDBRating = 7.2 }
let movie4 = { Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = director4; IMDBRating = 7.6 }
let movie5 = { Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = director5; IMDBRating = 8.1 }
let movie6 = { Name = "King Richard"; RunLength = 144; Genre = Sport; Director = director6; IMDBRating = 7.5 }
let movie7 = { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = director7; IMDBRating = 7.4 }
let movie8 = { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = director8; IMDBRating = 7.1 }

(*Create a list of movies.
Add all the movies to a list that we will use in subsequent steps.*)
let movies = [movie1; movie2; movie3; movie4; movie5; movie6; movie7; movie8]
printfn "\nList of Movies (provided in table):"
movies
|> List.iter (fun movie ->
    printfn "Name: %s, Run Length: %d min, Genre: %A, Director: %s, IMDB Rating: %.1f"
        movie.Name movie.RunLength movie.Genre movie.Director.Name movie.IMDBRating)

(*Identify probable Oscar winners.
Find the list of probable Oscar winners by applying the filter function to fetch movies that have an IMDB rating greater than 7.4.*)
let probableOscarWinners =
    movies
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)

printfn "\nProbable Oscar Winners:"
probableOscarWinners
|> List.iter (fun movie ->
    printfn "Name: %s, IMDB Rating: %.1f" movie.Name movie.IMDBRating)

(*Convert movie run length to hours.
Using a map function, convert the run length from minutes to hours and minutes format. 
For example, 111 should be converted into "1h 51min." The resulting list will be a list of strings, because the result will be stored in "_h _ _min" format.*)
let convertRunLengthToHoursAndMinutes (runLength: int) =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes
let runLengthsInHoursAndMinutes =
    movies
    |> List.map (fun movie -> convertRunLengthToHoursAndMinutes movie.RunLength)
printfn "\nRun Lengths in Hours and Minutes:"
runLengthsInHoursAndMinutes
|> List.iter (printfn "%s")
//Diana T
//23094277
//CPSem3