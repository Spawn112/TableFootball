This project is running .NET MVC and a 3-tier architecture and a component-based architecture. Try to follow the path set with layering things.

TableFootball.Data is our datalayer and should contain CRUD functionality for our data.
TableFootball.Datatypes is our entities as they are represented in the database of our choosing
TableFootball is our logiclayer and should have services that get the data from out datalayer and should be where all the logic is. (i.e. Scoring algoritms etc.)
TableFootball.Website is our presentation layer and the website that we present and deploy.

Our Frontend is done in the Design folder on the root folder of our solution and is to be run in VS Code. When installing/running VS Code install the recommended extensions and remember to turn on "watch sass".

OBS!: For the data to work you need to have a local MongoDB installed. (select an editor of your choosing for working with the data in the MongoDB instance directly)