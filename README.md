# CardGame


"Card Clash: Higher or Lower" is a simple and exciting card game where you compete against the computer to see who can draw the higher card. 
In each round, both you and the computer draw a card from a shuffled deck, and the one with the higher card wins the round. Play and test your luck to see if you can outdraw the computer and claim victory!

Steps to run the Project
 1. Run the API project
 2. You will see a swagger page 
 3. Run the First API which is CardClash
 4. Hit the API and it will draw card for both player and computer and whoever has the higher values wins the round.

Understanding of the Project=>
Here we are following Clean Architecture 
1. CardGame.API  is the presentatation layer
2. CardGame.Application is the Application or Use Case layer where we write the business logic and often grouped into Commands and Queries, following CQRS
3. CardGame.Domain is the project where we have kept all our entities which will be helpful when we are communicating with database or  can leverage Domain Events to communicate changes to other parts of the system.
4. CardGame.Infrastructure is the project which we will be responsible for implementing the repository class and it is concerned with EF, Files, Email, Web Services,    Azure/AWS/GCP, etc is Infrastructure 