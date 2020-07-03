Overview
#Goals:
Cover the most common build tasks for a web-based RESTful API service
Observe design patterns and areas for improvement and knowledge gaps
Exposure to common third-party development packages used when developing

#Areas Covered:
Frameworks: ASP.NET Core, MVC
Basic route setup
Data Access: Dapper
Interfaces
Validation
Unit Testing
Databases: Initial Setup, Tables and Stored procedures, Basic SQL
C#
API Documentation (Swagger)
JSON based

#Tasks

#[x] visual studio - create an MVC app called MoviesAPI
[x] create a Movie.cs model, a class model
[x] create a movie controller:
    [ ]All request params sent in body:
    [ ]Username sent in Header
    [ ]Username must not be null

[ ] Create GetMovie method: Method to return movies details for a specific movie. using Input ID.

    input:
    [x]int ID

    output:
    [x]Returns all movie details for a particular movie

    Validation:
    [ ]Id be an int bigger than 0

     GetMovie Error Handling:
    [ ]400 for invalid input type or null
    [ ]404 for not found
    [ ]500 for server error

[ ] Create GetAllMovies method: Method to return all movies with no inputs.

    logging:
    [ ]request and response to console

    input:
    [x]null

    output:
    [x] Movie type


    GetMovie Error Handling:
    [ ]400 for invalid input type or null
    [ ]404 for not found
    [ ]500 for server error

[ ] Create AddMovie Method:Method to insert a new movie record.

    logging:
    [ ]request and response to console

    input:
    [x]All movie properties except Id

    output:
    [x]Created Movie Record

    Validation:
    [x]all properties to exist as correct type

    AddMovie error handling
    [ ]400 for invalid input type or null
    [ ]500 for server error

[ ]Create DeleteMovie Method:Method to delete an existing movie.

    logging:
    [ ]request and response to console

    input:
    [x]int ID

    output:
    [x]return remaining movies from DB 

    Error Handling:
    [ ]400 for invalid input type or null
    [ ]404 for not found
    [ ]500 for server error


#[x]Azzure data studio - create a database called MoviesDB

Extensions database:
[x]SP Name: “GetMovie”
input:
[x]int Id
output:
[x]MovieID, MovieName, AgeRating, Price, ReleaseDate, Genre

[x]SP Name: “GetAllMovies”
input:
[x]none
output:
[x]All records in movies table

[x]SP Name: “InsertMovie”
input:
[x]MovieName, AgeRating, Price, ReleaseDate, Genre 
output:
[x]Create movie record

[x]SP Name: “DeleteMovie”
input:
[x] int Id
output:
[x] Successful response from DB



#[x] install Dapper nuget package
#[x] connect MoviesAPI to database
#[ ] use postman to validate APIs created
#[ ] Sign up to Swagger for API documentation