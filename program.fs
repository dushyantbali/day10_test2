type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

type Director = {
    Name: string
    Movies: int
}

type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    ImdbRating: float
}

let directors = [
    { Name = "Sian Heder"; Movies = 9 }
    { Name = "Kenneth Branagh"; Movies = 23 }
    { Name = "Adam McKay"; Movies = 27 }
    { Name = "Ryosuke Hamaguchi"; Movies = 16 }
    { Name = "Denis Villeneuve"; Movies = 24 }
    { Name = "Reinaldo Marcus Green"; Movies = 15 }
    { Name = "Paul Thomas Anderson"; Movies = 49 }
    { Name = "Guillermo Del Toro"; Movies = 22 }
]

let movies = [
    { Name = "CODA"; RunLength = 111; Genre = Drama; Director = directors.[0]; ImdbRating = 8.1 }
    { Name = "Belfast"; RunLength = 98; Genre = Drama; Director = directors.[1]; ImdbRating = 7.3 }
    { Name = "Don’t Look Up"; RunLength = 138; Genre = Comedy; Director = directors.[2]; ImdbRating = 7.2 }
    { Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = directors.[3]; ImdbRating = 7.6 }
    { Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = directors.[4]; ImdbRating = 8.1 }
    { Name = "King Richard"; RunLength = 144; Genre = Sport; Director = directors.[5]; ImdbRating = 7.5 }
    { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = directors.[6]; ImdbRating = 7.4 }
    { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = directors.[7]; ImdbRating = 7.1 }
]

let oscarWinners = 
    movies
    |> List.filter (fun m -> m.ImdbRating > 7.4)

let convertRunLength runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

let runLengthsConverted =
    movies
    |> List.map (fun m -> m.Name, convertRunLength m.RunLength)

printfn "Probable Oscar Winners:"
oscarWinners |> List.iter (fun m -> 
    printfn "Name: %s, Genre: %A, IMDB Rating: %.1f" m.Name m.Genre m.ImdbRating
)

printfn "\nRun Lengths Converted to Hours and Minutes:"
runLengthsConverted |> List.iter (fun (name, time) -> 
    printfn "Movie: %s, Run Time: %s" name time
)