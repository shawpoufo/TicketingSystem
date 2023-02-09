# Technologies
![.NET](https://img.shields.io/badge/.NET7-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![asp.netCore](https://img.shields.io/badge/Asp.netCore-6c429c?style=for-the-badge&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-59b4d9?style=for-the-badge&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%23563D7C.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![git](https://img.shields.io/badge/GIT-F05032?style=for-the-badge&logo=git&logoColor=white)
![tabulator](https://img.shields.io/badge/Tabulator-49ad4a?style=for-the-badge&link=https://tabulator.info/)
# Introduction
Un système de ticket il vous aider à améliorer votre service client en fournissant un moyen centralisé, organisé et efficace de gérer les demandes des clients. Il simplifie le processus d'assistance à vos clients en catégorisant et en priorisant leurs demandes, en les affectant aux membres de l'équipe appropriés et en fournissant des réponses en temps réel.
# Installation
1. [Télécharger docker desktop](https://www.docker.com/products/docker-desktop/)
2. Cloner le projet
``git clone https://github.com/shawpoufo/TicketingSystem.git``
3. Se positionner sur le dossier du projet
 `cd TicketingSystem`
 4. Lancer application à l'aide de docker-compose
 `docker-compose up`
 5. Lancer le l'adresse de l'application front dans le navigateur web
 `http://localhost:5005/`
# Adresses des micro-service
 - application front-end : [http://localhost:5005 ](http://localhost:5005/)
 - GateWay : [http://localhost:5000 ](http://localhost:5000/)
 - CustomIdentity : [http://localhost:5001 ](http://localhost:5001/)
 - Ticket : [http://localhost:5002](http://localhost:5002/)
 - Organisation : [http://localhost:5003](http://localhost:5003/)
 - Conversation : [http://localhost:5004](http://localhost:5004/)
# Captures d'écran
## Page d'acceuil
![home](image/readme/home.png)

## Page de connection
![Login](image/readme/login.png)
## Page d'enregistrement
![SignUp](image/readme/signup.png)
## Page de list des organismes
Un organisme est une entité qui rassemble tous vos clients de votre produit et les agents qui vont résoudre leur problème.
![organisation](image/readme/organisation.png)
## Formulaire pour ajouter un organisme
![organisation](image/readme/organisationForm.png)
## Tableau de bord de l'admin
À partir de ce tableau de bord l'admin peut suivre l'état d'avancement des problèmes postuler par les clients en temps réel, chaque ticket est un problème qui doit être résolue par un agent, un ticket dispose de trois états.
![adminDashboard](image/readme/adminDashboard.png)
### Attribuer un ticket à un agent
Afin de attribuer un ticket il va faloir avoire un agent sinon ajouter le dans l'onglet des agents
![assignTickets](image/readme/assignTickets.png)
## Onglet des client
La page des clients affiche les clients d'un organisme choisi ainsi que l'état de leur présence (online/offline) en temps-réel
![clientsList](image/readme/clientsList.png)
## Tableau de bord du client
à travers cette page le client peut :
- Remplire un nouveau ticket
- Consulter l'état d'anvancement des ticket
- Communiquer en temps-réel (chat) avec l'agent
*NOTE : l'agent dispose d'une interface similaire*
![clientDashboard](image/readme/clientDashboard.png)




