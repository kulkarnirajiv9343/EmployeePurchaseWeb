This is a simple ASP.NET MVC application to post an employee purchase data to a database. I have used ASP.NET MVC 5 to create the web application and the web api. 
The estimated time for this task was around 4 hours, but it took double to actually finish the task due to some snags encountered.
The reason for selecting this stack was because of my long years of esperience working with it. 
I assumed this to be a simple web application that displays a web page having employee purchases listed out on the home page. Clicking on the Create link displays a form for the user to enter the purchase info- Purchase date, Amount, Description and an image of the receipt. Here are a couple issues I ran into that I had to overcome:
1. Bootstrap 5 does not provide a datepicker out of the box, so had to go for a jquery datepicket for the purchase date field.
2. I was not sure if the receipt image needs to be stored on the server in a folder or to the database. I referred to the task description again and decided to save it to the database (which might not be recommended due to the data size in its binary form)
3. I used a sqlexpress database I created using code first approach. I have some sample data posted to the database.
4. A couple nice thing to have which I did not include would be: dependency injection (I was planning to add a StructureMap container, but decided against adding any), a textarea field instead of a regular textbox for the description (which I might add and commit).
5. I assumed that only the Create part is part of the task, so I did not fully implement the Edit and Details part which need some work on the image display (currently displaying the image in its binary format).
6. I was looking for a best way to post the image to the database. I tested it directly from the mvc web app (without the web api), creating the database using the Code First approach. I then added the Web API using the same database I added before using the Database First approach with EF. 
