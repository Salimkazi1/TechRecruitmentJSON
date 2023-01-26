# TechRecruitmentJSON

Good morning everyone,
I've submited the test successfully in a .NET project and in this readMe file, I will describe some details that need to be shared.

As a starter, we need the visual studio 2022 to be able to launch the project.
Once the .sln file launched, you will be able to look at the solution file explorer at the right side of the window.

I've worked with a library called Newton.Json.Schema (stored in the dependencies node->packages) to be able to validate or not the given JSON files in the correct formats.
The Validator Controller stored in the Controller folder is the file where are coded my POST requests.

The infrastructure folder holds the fileformat (the way we read our JSON file) and the APIKEYMIDDLEWARE (I've added this bonus feature to secure a bit this public solution).

The models folder includes our "data" section of the project (even thought we don't have data to manipulate, given the inputs, I've done the exact architecture as it was
one of my MVC projects)

The resource folder contains the datamodelschema to work with.

The JsonValidatorService is the file where are coded our main Validations mehtods.

And finally the program.cs file which contains all of our different features, middlewares to make the project work.

You can directly launch the project with the HTTP launch mode (green play button launching the project in the visual studio window)
Once the swagger UI appears in the browser window, you will have a button at the right side of the page taged "authorize", click on it and paste the API key stored
in the appsettings.json file of the project, once authorized, you can go to the second POST endpoint, click on the Try it out button then upload the needed JSON files
to check if it's valid or not. If we edit something in the file and it's not in the valid format, the error will be described with the right location at the file.

