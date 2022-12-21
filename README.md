# TestTaskAkvelon
This project has been designed for applying for the Junior .NET developer internship at Akvelon - 
                              appliers have to Implement a Web API for entering data into the database and so I did using Entity Framework.
    
There is a Models folder that includes entities and repositories as well as a Controllers folder.
In the project there are 2 entities = ProjectTask and Project. ProjectTask is an instace that contains 4 fields - Id, Name, Description and ProjectId. 
Each task is a part of only one project. Project, in turn, contains Id, Name, Description and a list of ProjectTasks.
                                             
ProjectTask and Project are kept in the Models folder of the project. In this folder you can also see repositories for Project and 
   ProjectTask (as well as their interfaces) entities that integrate all of the fundamental data operations related to the entities.

To provide simplified access to database and data stored in there I implemented Data Access Layer named DataBaseContext that connects to the local DB.

Controllers determines what response to send back to a user when a user makes a browser request. Since there are only 2 entities - ProjectTask and Project - 
   there 2 controllers for them - ProjectTask Controller and ProjectController.
   In order to make requests and test the Web API, there is Swagger automatically provided in the project. 
    You can easily try out requests. I have done those myself and they work!
